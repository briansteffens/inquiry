/*
 * This file contains classes necessary for storing, loading, and modifying Inquiry projects and queries.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ColdPlace.Inquiry
{
    /// <summary>
    /// Represents an Inquiry project including folders, queries, value sets, and project-specific connection strings.
    /// </summary>
    public class QueryProject
    {

        #region General

        public QueryProject()
        {
            Root = new Folder();
            Root.Project = this;
            Root.Name = "Root";

            ConnectionStrings = new ConnectionStringList(true);
            ValueSets = new List<ValueSet>();
        }

        
        /// <summary>
        /// Gets or sets whether this project contains unsaved changes.
        /// </summary>
        public bool Dirty
        {
            get
            {
                return m_Dirty;
            }
            set
            {
                bool changed = m_Dirty != value;
                m_Dirty = value;
                if (DirtyChanged != null) DirtyChanged(this, new EventArgs());
            }
        }
        bool m_Dirty = true;


        /// <summary>
        /// The root node from which all other folders and queries descend.
        /// </summary>
        public Folder Root { get; set; }


        /// <summary>
        /// Occurs when an unsaved change has happened to the project.
        /// </summary>
        public event EventHandler DirtyChanged;

        #endregion


        #region Query Actions

        /// <summary>
        /// Creates a new query as a child of [destination].
        /// </summary>
        /// <param name="destination">The parent node of the new node. If [destination] is a query, the new query will be its sibling.</param>
        /// <returns>The new query.</returns>
        public Query NewQuery(QueryNode destination)
        {
            if (!(destination is Folder))
                destination = GetParentNode(destination);

            Folder folder = (Folder)destination;

            int i = 1;
            while (folder.ContainsName("Query " + i.ToString()))
                i++;

            Query query = new Query()
            {
                Project = this,
                Name = "Query " + i.ToString(),
                DatabaseName = "",
                QueryText = ""
            };

            folder.Children.Add(query);
            Dirty = true;

            return query;
        }


        /// <summary>
        /// Deletes [node] from the project.
        /// </summary>
        /// <param name="node">The node to delete.</param>
        public void DeleteNode(QueryNode node)
        {
            QueryNode parent = GetParentNode(node);
            ((Folder)parent).Children.Remove(node);

            Dirty = true;
        }


        /// <summary>
        /// Creates an exact copy of [query] as a sibling to [query].
        /// </summary>
        /// <param name="query">The query to clone.</param>
        public void Clone(Query query)
        {
            Folder parent = (Folder)GetParentNode(query);

            Query q = new Query()
            {
                Project = this,
                DatabaseName = query.DatabaseName,
                Description = query.Description,
                QueryText = query.QueryText
            };

            q.Name = "Copy of " + query.Name;
            int i = 1;
            while (parent.ContainsName(q.Name))
            {
                i++;
                q.Name = "Copy of " + query.Name + " " + i.ToString();
            }

            parent.Children.Add(q);
        }


        /// <summary>
        /// Reorders [node] among its siblings.
        /// </summary>
        /// <param name="node">The node to move.</param>
        /// <param name="up">Move the node up (true) or down (false).</param>
        public void MoveNodeVertical(QueryNode node, bool up)
        {
            Folder parent = (Folder)GetParentNode(node);
            int index = parent.Children.IndexOf(node);

            index += up ? -1 : 1;

            if (index < 0) index = 0;
            if (index > parent.Children.Count - 1) index = parent.Children.Count - 1;

            parent.Children.Remove(node);
            parent.Children.Insert(index, node);
        }


        /// <summary>
        /// Moves [from] to be a child of [to].
        /// </summary>
        /// <param name="from">The node to move.</param>
        /// <param name="to">[from]'s new parent. If [to] is a query, [from] will become its sibling.</param>
        public void MoveNode(QueryNode from, QueryNode to)
        {
            QueryNode fromParent = GetParentNode(from);

            QueryNode toParent = to;
            if (to is Query)
                toParent = GetParentNode(to);

            if (from is Folder)
                if (IsSubNode((Folder)from, toParent))
                {
                    System.Windows.Forms.MessageBox.Show("A node cannot be added to a child node of its own.");
                    return;
                }

            if (((Folder)toParent).Children.Find(p => p.Name == from.Name) != null)
            {
                System.Windows.Forms.MessageBox.Show("A conflicting name already exists in the destination folder.");
                return;
            }

            ((Folder)fromParent).Children.Remove(from);
            ((Folder)toParent).Children.Add(from);

            Dirty = true;
        }

        #endregion


        #region Query Information

        /// <summary>
        /// Recursively searches for a specific node by [path] which has [search] as an ancestor.
        /// </summary>
        /// <param name="search">The node to search.</param>
        /// <param name="path">The path of the node to find, separated by backslashes. (folder1\folder2\query)</param>
        /// <returns>The node if it was found, null if not.</returns>
        public QueryNode ByPath(string path)
        {
            if (path == "")
                return Root;

            return ByPath(Root, path);
        }


        /// <summary>
        /// Recursively searches for a specific node by [path] which has [search] as an ancestor.
        /// </summary>
        /// <param name="search">The node to search.</param>
        /// <param name="path">The path of the node to find, separated by backslashes. (folder1\folder2\query)</param>
        /// <returns>The node if it was found, null if not.</returns>
        QueryNode ByPath(Folder search, string path)
        {
            string[] spl = path.Split('\\');
            string local = spl[0];

            List<string> splice = new List<string>();
            for (int i = 1; i < spl.Length; i++)
                splice.Add(spl[i]);

            string nextLevel = string.Join("\\", splice.ToArray());

            foreach (QueryNode node in search.Children)
            {
                if (node.Name != local)
                    continue;

                if (node is Folder && spl.Length > 1)
                    return ByPath((Folder)node, nextLevel);

                return node;
            }

            return null;
        }


        /// <summary>
        /// Recursively finds all folders in the project, including Root.
        /// </summary>
        /// <returns>All folders in the project.</returns>
        public List<Folder> GetAllFolders()
        {
            List<Folder> ret = new List<Folder>();

            ret.Add(Root);
            foreach (Folder f in GetSubFolders(Root))
                ret.Add(f);

            return ret;
        }


        /// <summary>
        /// Recursively finds all folders that are descendants of [folder].
        /// </summary>
        /// <param name="folder">The folder to search.</param>
        /// <returns>All folders with [folder] as an ancestor.</returns>
        public IEnumerable<Folder> GetSubFolders(Folder folder)
        {
            foreach (QueryNode qn in folder.Children)
                if (qn is Folder)
                {
                    yield return (Folder)qn;

                    foreach (Folder f2 in GetSubFolders((Folder)qn)) // Continue recursion
                        yield return f2;
                }
        }


        /// <summary>
        /// Recursively finds all queries with [folder] as an ancestor.
        /// </summary>
        /// <param name="folder">The folder to search.</param>
        /// <returns>All descendants of [folder].</returns>
        public IEnumerable<Query> GetSubQueries(Folder folder)
        {
            foreach (QueryNode qn in folder.Children)
                if (qn is Query)
                    yield return (Query)qn;
                else if (qn is Folder)
                    foreach (Query q in GetSubQueries((Folder)qn)) // Continue recursion.
                        yield return q;
        }


        /// <summary>
        /// Gets the direct parent node of [node]. This is recursive and will search Root and all descendants of Root.
        /// </summary>
        /// <param name="node">The node whose parent should be returned.</param>
        /// <returns>The direct parent of [node] or null if [node] does not have a parent (IE: if it's the root node).</returns>
        public QueryNode GetParentNode(QueryNode node)
        {
            List<Folder> folders = GetAllFolders(); // Get all folders in the project

            foreach (Folder search in folders)
                if (search.Children.Contains(node))
                    return search;

            return null;
        }


        /// <summary>
        /// Recursively checks if [parent] is an ancestor of [sub].
        /// </summary>
        /// <param name="parent">The folder to check.</param>
        /// <param name="sub">The node to search for.</param>
        /// <returns>True if [parent] is an ancestor of [sub], false if not.</returns>
        public bool IsSubNode(Folder parent, QueryNode sub)
        {
            if (parent.ContainsName(sub.Name))
                return true;

            foreach (QueryNode qn in parent.Children)
            {
                if (!(qn is Folder))
                    continue;

                bool ret = IsSubNode((Folder)qn, sub); // Continue recursion

                if (ret)
                    return ret;
            }

            return false;
        }

        #endregion


        #region Parameters

        /// <summary>
        /// All value sets in this project.
        /// </summary>
        public List<ValueSet> ValueSets { get; set; }


        /// <summary>
        /// The name of the current value set.
        /// </summary>
        public string CurrentValueSetName { get; set; }


        /// <summary>
        /// Gets the current value set. If one is not set, it will attempt to set value set "Default" to current and return that.
        /// If all else fails, it will create a new, empty "Default" value set and return it.
        /// </summary>
        public ValueSet CurrentValueSet
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentValueSetName))
                    CurrentValueSetName = "Default";

                if (ValueSets.Find(p => p.Name == CurrentValueSetName) == null)
                {
                    ValueSet vs = new ValueSet();
                    vs.Name = "Default";
                    ValueSets.Add(vs);
                }

                return ValueSets.Find(p => p.Name == CurrentValueSetName);
            }
        }


        /// <summary>
        /// Retrieves all of the parameter names and values from the current value set in Dictionary<string, string> form.
        /// </summary>
        /// <returns>All parameter names and values. Key = name, Value = value.</returns>
        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();

            foreach (string key in CurrentValueSet.Parameters.Keys)
                ret[key] = CurrentValueSet.Parameters[key];

            return ret;
        }


        /// <summary>
        /// Get the parameter's value from the current value set.
        /// </summary>
        /// <param name="key">The name of the parameter.</param>
        /// <returns>The value of the parameter.</returns>
        public string GetParameter(string key)
        {
            return CurrentValueSet.Parameters[key];
        }


        /// <summary>
        /// Sets a parameter's value on the current value set. Silently ignores if the parameter does not exist.
        /// </summary>
        /// <param name="key">The name of the parameter to set.</param>
        /// <param name="value">The value to set the parameter to.</param>
        public void SetParameter(string key, string value)
        {
            if (!CurrentValueSet.Parameters.ContainsKey(key)) // Ignore if the value set does not contain a parameter by this name.
                return;

            if (CurrentValueSet.Parameters[key] == value) // Ignore if the parameter's value is already the value it's being set to.
                return;

            CurrentValueSet.Parameters[key] = value;

            Dirty = true;
        }


        /// <summary>
        /// Adds a parameter to all value sets. The parameter's value will default to an empty string.
        /// </summary>
        /// <param name="key">The name of the new parameter.</param>
        public void AddParameter(string key)
        {
            foreach (ValueSet vs in ValueSets)
                vs.Parameters.Add(key, "");

            Dirty = true;
        }
        
        
        /// <summary>
        /// Removes a parameter from all value sets.
        /// </summary>
        /// <param name="key">The name of the parameter to remove.</param>
        public void RemoveParameter(string key)
        {
            foreach (ValueSet vs in ValueSets)
                vs.Parameters.Remove(key);

            Dirty = true;
        }


        /// <summary>
        /// Checks for a parameter's existence by name.
        /// </summary>
        /// <param name="key">The parameter name to search for.</param>
        /// <returns>True if a parameter by the specified name was found, false otherwise.</returns>
        public bool ParameterExists(string key)
        {
            return CurrentValueSet.Parameters.ContainsKey(key);
        }

        #endregion


        #region Connection Strings

        /// <summary>
        /// Project-specific connection strings, stored in the project file.
        /// </summary>
        public ConnectionStringList ConnectionStrings { get; set; }

        #endregion


        #region Serialization

        // Recursively load all folders and queries in supplied XML fragment, placing them in supplied folder.
        void RecursiveLoad(Folder folder, XElement element)
        {
            XAttribute attr = null;

            foreach (XElement ele in element.Elements())
                switch (ele.Name.LocalName)
                {
                    case "Folder":
                        Folder f = new Folder();
                        f.Project = this;
                        f.Name = ele.Attribute("Name").Value;

                        attr = ele.Attribute("IsExpanded");
                        if (attr != null) f.IsExpanded = bool.Parse(attr.Value);

                        folder.Children.Add(f);

                        RecursiveLoad(f, ele); // Continue recursion

                        break;

                    case "Query":
                        Query q = new Query()
                        {
                            Project = this,
                            Name = ele.Attribute("Name").Value,
                            DatabaseName = ele.Attribute("DatabaseName").Value,
                            QueryText = ele.Attribute("QueryText").Value
                        };

                        attr = ele.Attribute("Description");
                        if (attr != null) q.Description = attr.Value;

                        attr = ele.Attribute("SafeMode");
                        if (attr != null) q.SafeMode = bool.Parse(attr.Value);

                        folder.Children.Add(q);

                        break;
                }
        }


        /// <summary>
        /// Load project from specified file and populate this instance with the data.
        /// </summary>
        /// <param name="filename">The project file to load.</param>
        public void Load(string filename)
        {
            XDocument doc = XDocument.Parse(System.IO.File.ReadAllText(filename));
            XElement root = doc.Element("QueryProject");


            // Load folders and queries
            XElement queryRoot = root.Element("Folder");
            if (queryRoot != null)
            {
                Root = new Folder();
                Root.Project = this;
                Root.Name = "Root";

                RecursiveLoad(Root, queryRoot);
            }


            // Load value sets
            XElement valueSets = root.Element("ValueSets");
            if (valueSets != null)
            {
                XAttribute attr = valueSets.Attribute("Current");
                if (attr != null) CurrentValueSetName = attr.Value;

                foreach (XElement valueSet in valueSets.Elements("ValueSet"))
                    ValueSets.Add(new ValueSet(valueSet));
            }


            /// Load project-specific connection strings
            XElement csele = root.Element("ConnectionStringList");
            if (csele != null)
                ConnectionStrings = new ConnectionStringList(csele);
            else
                ConnectionStrings = new ConnectionStringList(true);


            Dirty = false; // File is newly-loaded, so this project is not dirty
        }


        // Recursively save all folders and queries in supplied folder to supplied XML fragment
        void RecursiveSave(XElement ele, Folder folder)
        {
            foreach (QueryNode node in folder.Children)
            {
                if (node is Folder)
                {
                    Folder f = (Folder)node;

                    XElement fele = new XElement("Folder");
                    fele.SetAttributeValue("Name", f.Name);
                    fele.SetAttributeValue("IsExpanded", f.IsExpanded.ToString());

                    RecursiveSave(fele, f); // Continue recursion

                    ele.Add(fele);
                }
                else if (node is Query)
                {
                    Query q = (Query)node;

                    XElement qele = new XElement("Query");

                    qele.SetAttributeValue("Name", q.Name);
                    qele.SetAttributeValue("DatabaseName", q.DatabaseName);
                    qele.SetAttributeValue("QueryText", q.QueryText);
                    qele.SetAttributeValue("Description", q.Description);
                    qele.SetAttributeValue("SafeMode", q.SafeMode);

                    ele.Add(qele);
                }
            }
        }


        /// <summary>
        /// Saves this project to specified file.
        /// </summary>
        /// <param name="filename">File in which to store this project.</param>
        public void Save(string filename)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("QueryProject");


            // Save folders and queries
            XElement queryRoot = new XElement("Folder");
            queryRoot.SetAttributeValue("Name", "Root");

            RecursiveSave(queryRoot, Root);

            root.Add(queryRoot);


            // Save value sets
            XElement valueSets = new XElement("ValueSets");
            valueSets.SetAttributeValue("Current", CurrentValueSetName ?? "");
            foreach (ValueSet valueSet in ValueSets)
                valueSets.Add(valueSet.Save());
            root.Add(valueSets);


            // Save project-specific connection strings
            root.Add(ConnectionStrings.SaveToXElement());


            // Write XML file
            doc.Add(root);
            System.IO.File.WriteAllText(filename, doc.ToString());

            Dirty = false; // File has been saved, so this project is no longer dirty
        }

        #endregion

    }


    /// <summary>
    /// A value set as controlled by the parameters pane in the main UI.
    /// </summary>
    public class ValueSet
    {
        public string Name { get; set; }


        /// <summary>
        /// The names and values of all parameters in this value set.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }


        public override string ToString()
        {
            return Name;
        }

        public ValueSet()
        {
            Parameters = new Dictionary<string, string>();
        }


        /// <summary>
        /// Creates a ValueSet instance, with data loaded from the supplied XML fragment.
        /// </summary>
        /// <param name="ele">XML fragment containing value set data.</param>
        public ValueSet(XElement ele)
            : this()
        {
            Name = ele.Attribute("Name").Value;

            foreach (XElement p in ele.Elements("Parameter"))
            {
                string key = p.Attribute("Key").Value;
                string value = p.Attribute("Value").Value;

                Parameters.Add(key, value);
            }
        }


        /// <summary>
        /// Serialize the content of this instance into XML for storage on disk.
        /// </summary>
        /// <returns>An XML fragment representing this instance.</returns>
        public XElement Save()
        {
            XElement ele = new XElement("ValueSet");
            ele.SetAttributeValue("Name", Name);

            foreach (string key in Parameters.Keys)
            {
                XElement p = new XElement("Parameter");
                
                p.SetAttributeValue("Key", key);
                p.SetAttributeValue("Value", Parameters[key]);
                
                ele.Add(p);
            }

            return ele;
        }
    }


    /// <summary>
    /// Base class for Folder and Query, representing a generic node in a QueryProject.
    /// </summary>
    public class QueryNode
    {
        /// <summary>
        /// The QueryProject this node belongs to.
        /// </summary>
        public QueryProject Project { get; set; }


        /// <summary>
        /// The query/folder's name
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                if (m_Name != value) // Set the Dirty flag in the QueryProject so the UI knows if it needs to prompt to save changes
                    Project.Dirty = true;

                m_Name = value;
            }
        }
        string m_Name = null;
    }


    /// <summary>
    /// A folder in a QueryProject. Can contain any number of QueryNode children (queries or folders). In the case of folders, this
    /// can be recursive. An instance of this type is used as the root node in a QueryProject.
    /// </summary>
    public class Folder : QueryNode
    {
        /// <summary>
        /// Whether or not this folder is expanded in the UI project view pane.
        /// </summary>
        public bool IsExpanded { get; set; }


        /// <summary>
        /// The children belonging to this folder.
        /// </summary>
        public List<QueryNode> Children { get; set; }


        /// <summary>
        /// Checks for a child node with the given name. This is not recursive (searches only this node's direct children).
        /// </summary>
        /// <param name="name">The name of the child node for which to search.</param>
        /// <returns>True if a child exists with the given name, false if not.</returns>
        public bool ContainsName(string name)
        {
            foreach (QueryNode node in Children)
                if (node.Name == name)
                    return true;

            return false;
        }

        public Folder()
        {
            Children = new List<QueryNode>();
            IsExpanded = false;
        }
    }


    /// <summary>
    /// A query in a QueryProject.
    /// </summary>
    public class Query : QueryNode
    {
        /// <summary>
        /// The query's freeform description.
        /// </summary>
        public string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                if (m_Description != value)
                    Project.Dirty = true;

                m_Description = value;
            }
        }
        string m_Description = null;


        /// <summary>
        /// The name of the database this query is for (Options->Connection Strings).
        /// </summary>
        public string DatabaseName
        {
            get
            {
                return m_DatabaseName;
            }
            set
            {
                if (m_DatabaseName != value)
                    Project.Dirty = true;

                m_DatabaseName = value;
            }
        }
        string m_DatabaseName = null;


        /// <summary>
        /// The query's SQL code.
        /// </summary>
        public string QueryText
        {
            get
            {
                return m_QueryText;
            }
            set
            {
                if (m_QueryText != value)
                    Project.Dirty = true;

                m_QueryText = value;
            }
        }
        string m_QueryText = null;


        /// <summary>
        /// Safe query execution mode.
        /// </summary>
        public bool SafeMode
        {
            get
            {
                return m_SafeMode;
            }
            set
            {
                if (m_SafeMode != value)
                    Project.Dirty = true;

                m_SafeMode = value;
            }
        }
        bool m_SafeMode = false;
    }
}