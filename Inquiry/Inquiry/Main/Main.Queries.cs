using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace ColdPlace.Inquiry
{
    public partial class Main
    {
        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryNode n = null;
            if (QueryTree.SelectedNode == null)
                n = Project.Root;
            else
                n = Project.ByPath(QueryTree.SelectedNode.FullPath);

            if (!(n is Folder))
            {
                string[] spl0 = QueryTree.SelectedNode.FullPath.Split('\\');
                List<string> splice0 = new List<string>();
                for (int i = 0; i < spl0.Length - 1; i++)
                    splice0.Add(spl0[i]);
                string spliced0 = string.Join("\\", splice0.ToArray());
                n = Project.ByPath(spliced0);
            }
            Folder f = (Folder)n;

            string name = "New Folder";
            int a = 1;
            while (true)
            {
                bool found = false;
                foreach (QueryNode node in f.Children)
                    if (node.Name == name)
                    {
                        found = true;
                        break;
                    }

                if (!found) break;

                a++;
                name = "New Folder " + a.ToString();
            }


            Folder n3 = new Folder();
            n3.Project = Project;
            n3.Name = name;
            f.Children.Add(n3);

            updateTree();
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QueryTree.SelectedNode == null) return;

            QueryNode n = (QueryNode)QueryTree.SelectedNode.Tag;
            Project.MoveNodeVertical(n, true);

            updateTree();
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QueryTree.SelectedNode == null) return;

            QueryNode n = (QueryNode)QueryTree.SelectedNode.Tag;
            Project.MoveNodeVertical(n, false);

            updateTree();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QueryTree.SelectedNode == null) return;

            QueryTree.SelectedNode.BeginEdit();
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QueryTree.SelectedNode == null || !(QueryTree.SelectedNode.Tag is Query)) return;
            Project.Clone((Query)QueryTree.SelectedNode.Tag);
            updateTree();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QueryTree.SelectedNode == null) return;

            QueryNode n = (QueryNode)QueryTree.SelectedNode.Tag;

            int folders = 0, queries = 1;

            if (n is Folder)
            {
                Folder f = (Folder)n;

                folders = Project.GetSubFolders(f).ToList().Count + 1;
                queries = Project.GetSubQueries(f).ToList().Count;
            }

            if (DialogResult.Yes != MessageBox.Show(this, "This operation will permanently delete:\r\n\r\n\t" + queries.ToString() + " queries\r\n\t" + folders.ToString() + " folders\r\n\r\nAre you sure you want to continue?", "Confirm Delete", MessageBoxButtons.YesNoCancel))
                return;

            Project.DeleteNode(n);

            updateTree();
        }

        private void newQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryNode n = Project.Root;
            if (QueryTree.SelectedNode != null)
                n = Project.ByPath(QueryTree.SelectedNode.FullPath);

            Query query = Project.NewQuery(n);

            updateTree();

            OpenQuery2(query);
        }

        void OpenQuery2(Query query)
        {
            if (query == null)
            {
                MessageBox.Show("Query not found.");
                return;
            }

            foreach (Form childForm in MdiChildren)
            {
                if (!(childForm is QueryForm))
                    continue;

                QueryForm queryChildForm = (QueryForm)childForm;

                if (queryChildForm.Query == query)
                {
                    queryChildForm.BringToFront();
                    return;
                }
            }

            QueryForm form = new QueryForm();
            form.ParentForm = this;
            form.Query = query;
            form.MdiParent = this;
            form.Text = query.Name;
            form.Show();
        }


        void QueryTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
                return;

            string[] spl0 = e.Node.FullPath.Split('\\');
            List<string> splice0 = new List<string>();
            for (int i = 0; i < spl0.Length - 1; i++)
                splice0.Add(spl0[i]);
            string spliced0 = string.Join("\\", splice0.ToArray());
            QueryNode n = Project.ByPath(spliced0);
            Folder f = (Folder)n;

            bool found = false;
            foreach (QueryNode n2 in f.Children)
                if (n2.Name == e.Label)
                {
                    found = true;
                    break;
                }

            if (found)
            {
                e.CancelEdit = true;
                MessageBox.Show("There is a conflicting name in the folder.");
                return;
            }

            ((QueryNode)e.Node.Tag).Name = e.Label;

            e.CancelEdit = true;

            updateTree();
            SelectNodeInTree(QueryTree, QueryTree.Nodes, n);
        }
        void QueryTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            QueryNode qn = (QueryNode)e.Node.Tag;
            if (qn is Folder)
            {
                ((Folder)qn).IsExpanded = e.Node.IsExpanded;
            }
        }
        void QueryTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            object tag = QueryTree.SelectedNode.Tag;

            if (tag != null && !(tag is Query))
                return;

            OpenQuery2((Query)tag);
        }



        void updateTree()
        {
            QueryNode qn = null;
            if (QueryTree.SelectedNode != null) qn = (QueryNode)QueryTree.SelectedNode.Tag;

            QueryTree.BeginUpdate();
            QueryTree.Nodes.Clear();

            updateTree(QueryTree.Nodes, Project.Root);
            updateTreePersistExpand(QueryTree.Nodes);

            QueryTree.EndUpdate();

            if (qn != null) SelectNodeInTree(QueryTree, QueryTree.Nodes, qn);
        }
        void updateTree(TreeNodeCollection nodes, Folder f)
        {
            foreach (QueryNode node in f.Children)
                if (node is Folder)
                {
                    Folder folder = (Folder)node;

                    TreeNode n = new TreeNode(folder.Name);
                    n.Tag = folder;
                    n.ImageKey = "folder";
                    n.SelectedImageKey = "folder";
                    nodes.Add(n);

                    updateTree(n.Nodes, folder);
                }
                else if (node is Query)
                {
                    Query query = (Query)node;

                    TreeNode n = new TreeNode(query.Name);
                    n.Tag = query;
                    n.ImageKey = "query";
                    n.SelectedImageKey = "query";
                    nodes.Add(n);
                }
        }
        void updateTreePersistExpand(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                object tag = node.Tag;

                if (tag is Query)
                    continue;

                Folder folder = (Folder)tag;

                if (folder.IsExpanded)
                    node.Expand();
                else
                    node.Collapse();

                updateTreePersistExpand(node.Nodes);
            }
        }
        void SelectNodeInTree(TreeView tree, TreeNodeCollection nodes, QueryNode node)
        {
            foreach (TreeNode n in nodes)
            {
                if (n.Tag == node)
                {
                    tree.SelectedNode = n;
                    return;
                }

                SelectNodeInTree(tree, n.Nodes, node);
            }
        }



        void QueryTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            QueryTree.SelectedNode = QueryTree.GetNodeAt(new Point(e.X, e.Y));
        }
        void QueryTree_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            TreeNode node = QueryTree.GetNodeAt(new Point(e.X, e.Y));

            QueryListMenu.Show(QueryTree, new Point(e.X, e.Y));
        }
        void QueryTree_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                return;

            TreeNode sourceNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            TreeNode destinationNode = QueryTree.GetNodeAt(QueryTree.PointToClient(new Point(e.X, e.Y)));

            QueryNode n1 = Project.ByPath(sourceNode.FullPath);

            QueryNode n2 = null;
            if (destinationNode != null)
                n2 = Project.ByPath(destinationNode.FullPath);
            else
                n2 = Project.Root;

            Project.MoveNode(n1, n2);
            updateTree();
            SelectNodeInTree(QueryTree, QueryTree.Nodes, n1);
        }
        void QueryTree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        void QueryTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
    }
}
