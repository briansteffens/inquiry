/* ColdPlace.Inquiry - configuration code
 * 
 * This file contains code related to loading, saving, and accessing various configuration files for the Inquiry project.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ColdPlace.Inquiry
{
    /// <summary>
    /// Config.xml - general configuration for Inquiry including UI and default project path.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Default path for configuration files.
        /// </summary>
        public string CONFIG_DIRECTORY { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Inquiry"; } }
        public string CONFIG_FILE { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Inquiry\Config.xml"; } }

        /// <summary>
        /// Width (in pixels) of the left pane in the UI - project list, search, and parameters
        /// </summary>
        public int LeftPaneWidth { get; set; }

        /// <summary>
        /// Default project path.
        /// </summary>
        public string ProjectPath { get; set; }

        public FormWindowState WindowState { get; set; }
        public int WindowTop { get; set; }
        public int WindowLeft { get; set; }
        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }


        /// <summary>
        /// Attempts to load Config.xml. If it does not already exist, creates one with default values and loads that.
        /// </summary>
        public Config()
        {
            // Make sure config directory exists. If not, create it.
            if (!Directory.Exists(CONFIG_DIRECTORY))
                Directory.CreateDirectory(CONFIG_DIRECTORY);

            // If config file does not exist, set some defaults and create it using Save()
            if (!File.Exists(CONFIG_FILE))
            {
                LeftPaneWidth = 300;
                ProjectPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Save();
            }

            
            // Load config file and populate this instance with its data
            XDocument doc = XDocument.Parse(File.ReadAllText(CONFIG_FILE));
            XElement root = doc.Element("Config");

            LeftPaneWidth = int.Parse(root.Element("LeftPaneWidth").Attribute("Value").Value);
            ProjectPath = root.Element("ProjectPath").Attribute("Value").Value;

            if (root.Element("WindowState") != null) WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), root.Element("WindowState").Attribute("Value").Value);
            if (root.Element("WindowTop") != null) WindowTop = int.Parse(root.Element("WindowTop").Attribute("Value").Value);
            if (root.Element("WindowLeft") != null) WindowLeft = int.Parse(root.Element("WindowLeft").Attribute("Value").Value);
            if (root.Element("WindowHeight") != null) WindowHeight = int.Parse(root.Element("WindowHeight").Attribute("Value").Value);
            if (root.Element("WindowWidth") != null) WindowWidth = int.Parse(root.Element("WindowWidth").Attribute("Value").Value);
        }


        /// <summary>
        /// Saves current settings in this instance to the general configuration file.
        /// </summary>
        public void Save()
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("Config");

            XElement ele = new XElement("LeftPaneWidth");
            ele.SetAttributeValue("Value", LeftPaneWidth.ToString());
            root.Add(ele);

            ele = new XElement("ProjectPath");
            ele.SetAttributeValue("Value", ProjectPath);
            root.Add(ele);

            ele = new XElement("WindowState");
            ele.SetAttributeValue("Value", WindowState);
            root.Add(ele);

            ele = new XElement("WindowTop");
            ele.SetAttributeValue("Value", WindowTop);
            root.Add(ele);

            ele = new XElement("WindowLeft");
            ele.SetAttributeValue("Value", WindowLeft);
            root.Add(ele);

            ele = new XElement("WindowWidth");
            ele.SetAttributeValue("Value", WindowWidth);
            root.Add(ele);

            ele = new XElement("WindowHeight");
            ele.SetAttributeValue("Value", WindowHeight);
            root.Add(ele);

            doc.Add(root);

            File.WriteAllText(CONFIG_FILE, doc.ToString());
        }
    }



    /// <summary>
    /// CodeExportSettings.xml - the saved code exporter settings.
    /// </summary>
    public class CodeExportSettings
    {
        public string CODE_EXPORT_SETTINGS_FILE { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Inquiry\CodeExportSettings.xml"; } }
        
        public string Language { get; set; }
        public string ValueSet { get; set; }
        public string ExportTo { get; set; }
        public string ExportFile { get; set; }

        /// <summary>
        /// Parameters specific to the particular code exporter indicated by Language.
        /// </summary>
        public Dictionary<string, string> Params { get; set; }

        public CodeExportSettings()
        {
            Params = new Dictionary<string, string>();


            if (!File.Exists(CODE_EXPORT_SETTINGS_FILE))
                Save();


            XDocument doc = XDocument.Parse(File.ReadAllText(CODE_EXPORT_SETTINGS_FILE));
            XElement root = doc.Element("CodeExportSettings");

            XElement language = root.Element("Language");
            Language = language.Attribute("Value").Value;

            XElement valueSet = root.Element("ValueSet");
            if (valueSet != null) ValueSet = valueSet.Attribute("Value").Value;

            XElement exportTo = root.Element("ExportTo");
            ExportTo = exportTo.Attribute("Value").Value;

            XElement exportFile = root.Element("ExportFile");
            ExportFile = exportFile.Attribute("Value").Value;


            XElement parameters = root.Element("Params");

            Params = new Dictionary<string, string>();
            foreach (XElement ele in parameters.Elements("Param"))
                Params.Add(ele.Attribute("Key").Value, ele.Attribute("Value").Value);
        }

        public void Save()
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("CodeExportSettings");

            XElement ele = new XElement("Language");
            ele.SetAttributeValue("Value", Language ?? "");
            root.Add(ele);

            ele = new XElement("ValueSet");
            ele.SetAttributeValue("Value", ValueSet ?? "");
            root.Add(ele);

            ele = new XElement("ExportTo");
            ele.SetAttributeValue("Value", ExportTo ?? "");
            root.Add(ele);

            ele = new XElement("ExportFile");
            ele.SetAttributeValue("Value", ExportFile ?? "");
            root.Add(ele);


            XElement parameters = new XElement("Params");

            foreach (string key in Params.Keys)
            {
                ele = new XElement("Param");
                ele.SetAttributeValue("Key", key);
                ele.SetAttributeValue("Value", Params[key]);
                parameters.Add(ele);
            }

            root.Add(parameters);


            doc.Add(root);
            File.WriteAllText(CODE_EXPORT_SETTINGS_FILE, doc.ToString());
        }
    }



    /// <summary>
    /// ProjectList.xml - the customizable project menu in the UI.
    /// </summary>
    public class CommonProjectList : List<CommonProject>
    {
        public string COMMON_PROJECT_LIST_FILE { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Inquiry\ProjectList.xml"; } }

        public CommonProjectList()
        {
            if (!File.Exists(COMMON_PROJECT_LIST_FILE))
                Save();


            XDocument doc = XDocument.Parse(File.ReadAllText(COMMON_PROJECT_LIST_FILE));
            XElement root = doc.Element("ProjectList");

            foreach (XElement ele in root.Elements("ProjectListItem"))
            {
                CommonProject project = new CommonProject();

                project.Name = ele.Attribute("Name").Value;
                project.Path = ele.Attribute("File").Value;

                Add(project);
            }
        }

        public void Save()
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("ProjectList");

            foreach (CommonProject project in this)
            {
                XElement ele = new XElement("ProjectListItem");

                ele.SetAttributeValue("Name", project.Name);
                ele.SetAttributeValue("File", project.Path);

                root.Add(ele);
            }

            doc.Add(root);
            File.WriteAllText(COMMON_PROJECT_LIST_FILE, doc.ToString());
        }
    }

    /// <summary>
    /// A project in the customizable project menu in the UI.
    /// </summary>
    public class CommonProject
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }



    /// <summary>
    /// ConnectionStrings.xml - global connection strings.
    /// </summary>
    public class ConnectionStringList : List<ConnectionString>
    {
        public string CONNECTION_STRING_FILE { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Inquiry\ConnectionStrings.xml"; } }

        public ConnectionString ByName(string name)
        {
            return this.Find(p => p.FriendlyName == name);
        }

        public ConnectionStringList()
        {
            if (!File.Exists(CONNECTION_STRING_FILE))
                Save();


            XDocument doc = XDocument.Parse(System.IO.File.ReadAllText(CONNECTION_STRING_FILE));
            XElement list = doc.Element("ConnectionStringList");
            
            load(list);
        }

        public ConnectionStringList(XElement root)
        {
            load(root);
        }

        public ConnectionStringList(bool empty) { }

        void load(XElement root)
        {
            Clear();

            foreach (XElement connstr in root.Elements("ConnectionString"))
            {
                ConnectionString cs = new ConnectionString();

                cs.ServerType = (ServerType)Enum.Parse(typeof(ServerType), connstr.Attribute("ServerType").Value);
                cs.String = connstr.Attribute("String").Value;
                cs.FriendlyName = connstr.Attribute("FriendlyName").Value;

                this.Add(cs);
            }
        }

        public void Save()
        {
            XDocument doc = new XDocument();
            doc.Add(SaveToXElement());

            File.WriteAllText(CONNECTION_STRING_FILE, doc.ToString());
        }

        public XElement SaveToXElement()
        {
            XElement root = new XElement("ConnectionStringList");

            foreach (ConnectionString cs in this)
            {
                XElement ele = new XElement("ConnectionString");

                ele.SetAttributeValue("ServerType", cs.ServerType);
                ele.SetAttributeValue("String", cs.String);
                ele.SetAttributeValue("FriendlyName", cs.FriendlyName);

                root.Add(ele);
            }

            return root;
        }

        public ConnectionStringList Clone()
        {
            ConnectionStringList ret = new ConnectionStringList(true);

            foreach (ConnectionString cs in this)
                ret.Add(cs.Clone());

            return ret;
        }
    }

    /// <summary>
    /// A project- or global-scope connection string.
    /// </summary>
    public class ConnectionString
    {
        public ServerType ServerType { get; set; }
        public string String { get; set; }
        public string FriendlyName { get; set; }

        public ConnectionString Clone()
        {
            ConnectionString ret = new ConnectionString();

            ret.ServerType = ServerType;
            ret.String = String;
            ret.FriendlyName = FriendlyName;

            return ret;
        }
    }



    /// <summary>
    /// Extensions.xml - the loaded Inquiry extensions.
    /// </summary>
    public class ExtensionList : List<Extension>
    {
        public string EXTENSION_LIST_FILE { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Inquiry\Extensions.xml"; } }

        public new void Add(Extension extension)
        {
            if (null != this.Find(p => p.Path == extension.Path))
                return;

            base.Add(extension);
        }

        public ExtensionList()
        {
            if (!File.Exists(EXTENSION_LIST_FILE))
            {
                if (this.Count == 0)
                {
                    string[] parts = Assembly.GetExecutingAssembly().Location.Split('\\');
                    List<string> partsList = new List<string>(parts);
                    partsList.RemoveAt(partsList.Count - 1);
                    string path = string.Join("\\", partsList.ToArray());
                    path += "\\StandardExtensions.dll";

                    if (File.Exists(path))
                        this.Add(new Extension()
                        {
                            Path = path
                        });
                }

                Save();
            }


            XDocument doc = XDocument.Parse(File.ReadAllText(EXTENSION_LIST_FILE));
            XElement list = doc.Element("ExtensionList");

            foreach (XElement ext in list.Elements("Extension"))
            {
                Extension extension = new Extension();

                extension.Path = ext.Attribute("Path").Value;

                this.Add(extension);
            }
        }

        public void Save()
        {
            XDocument doc = new XDocument();
            XElement list = new XElement("ExtensionList");

            foreach (Extension ext in this)
            {
                XElement ele = new XElement("Extension");

                ele.SetAttributeValue("Path", ext.Path);

                list.Add(ele);
            }

            doc.Add(list);
            File.WriteAllText(EXTENSION_LIST_FILE, doc.ToString());
        }
    }

    /// <summary>
    /// A loaded Inquiry extension.
    /// </summary>
    public class Extension
    {
        public string Path { get; set; }

        Assembly m_Assembly = null;
        public Assembly Assembly
        {
            get
            {
                if (m_Assembly == null)
                {
                    m_Assembly = Assembly.LoadFile(Path);

                    Processors = new List<Processor>();
                    Type[] types = m_Assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (!type.IsSubclassOf(typeof(Processor))) continue;

                        Processors.Add((Processor)Activator.CreateInstance(type));
                    }

                    CodeExporters = new List<CodeExporter>();
                    types = m_Assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (!type.IsSubclassOf(typeof(CodeExporter))) continue;

                        CodeExporters.Add((CodeExporter)Activator.CreateInstance(type));
                    }
                }

                return m_Assembly;
            }
        }

        public List<Processor> Processors { get; set; }
        public List<CodeExporter> CodeExporters { get; set; }

        public Extension()
        {
            Processors = new List<Processor>();
            CodeExporters = new List<CodeExporter>();
        }
    }



    /// <summary>
    /// A DBMS type. Used chiefly by Dal, Query, and connection strings.
    /// </summary>
    public enum ServerType { MSSQL, MySQL, Access, Oracle }
}