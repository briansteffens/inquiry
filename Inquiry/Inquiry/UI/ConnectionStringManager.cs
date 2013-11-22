using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColdPlace.Inquiry
{
    public partial class ConnectionStringManager : Form
    {
        ConnectionStringList globalList, projectList;
        ConnectionString currentString = null;
        QueryProject Project;

        public ConnectionStringManager(QueryProject project)
        {
            InitializeComponent();

            Project = project;

            globalList = new ConnectionStringList();
            projectList = project.ConnectionStrings.Clone();
        }

        private void ConnectionStringManager_Load(object sender, EventArgs e)
        {
            updateList();

            Scope.Items.Add("Global");
            Scope.Items.Add("Project");

            foreach (string name in Enum.GetNames(typeof(ServerType)))
                ServerType.Items.Add(name);
        }

        void updateList()
        {
            StringList.BeginUpdate();
            StringList.Items.Clear();

            // Global
            foreach (ConnectionString cs in globalList)
            {
                ListViewItem lvi = new ListViewItem(cs.FriendlyName);
                
                lvi.SubItems.Add(cs.ServerType.ToString());
                lvi.Group = StringList.Groups["GlobalGroup"];
                lvi.Tag = cs;
                
                StringList.Items.Add(lvi);
            }

            // Project
            foreach (ConnectionString cs in projectList)
            {
                ListViewItem lvi = new ListViewItem(cs.FriendlyName);

                lvi.SubItems.Add(cs.ServerType.ToString());
                lvi.Group = StringList.Groups["ProjectGroup"];
                lvi.Tag = cs;

                StringList.Items.Add(lvi);
            }

            StringList.EndUpdate();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ConnectionString cs = new ConnectionString();
            
            cs.FriendlyName = "New Connection String";
            int i = 1;
            while (globalList.Find(p => p.FriendlyName == cs.FriendlyName) != null)
            {
                i++;
                cs.FriendlyName = "New Connection String " + i.ToString();
            }

            cs.ServerType = Inquiry.ServerType.MySQL;

            globalList.Add(cs);
            updateList();

            editString(cs);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (StringList.SelectedItems.Count != 1)
                return;

            ConnectionString cs = (ConnectionString)StringList.SelectedItems[0].Tag;
            
            ConnectionStringList list = findList(cs);
            list.Remove(cs);

            updateList();
            StringList_SelectedIndexChanged(this, new EventArgs());
        }

        void editString(ConnectionString cs)
        {
            if (currentString == cs)
                return;

            currentString = cs;

            ConnectionStringList list = findList(cs);

            StringName.Text = cs.FriendlyName;
            ConnString.Text = cs.String;
            Scope.Text = (list == globalList ? "Global" : "Project");
            ServerType.Text = cs.ServerType.ToString();

            bool setSelection = StringList.SelectedItems.Count != 1 || StringList.SelectedItems[0].Tag != cs;

            if (setSelection)
                foreach (ListViewItem lvi in StringList.Items)
                    lvi.Selected = (lvi.Tag == cs);
        }

        ConnectionStringList findList(ConnectionString cs)
        {
            if (globalList.Contains(cs))
                return globalList;

            if (projectList.Contains(cs))
                return projectList;

            return null;
        }

        private void StringList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditGroup.Enabled = (StringList.SelectedItems.Count == 1);
            if (!EditGroup.Enabled)
            {
                StringName.Text = "";
                ConnString.Text = "";
                Scope.Text = "Global";
                ServerType.Text = "MySQL";
                
                currentString = null;

                return;
            }

            ConnectionString cs = (ConnectionString)StringList.SelectedItems[0].Tag;
            editString(cs);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ConnectionStringList list = findList(currentString);
            ConnectionStringList destList = (Scope.Text == "Global" ? globalList : projectList);

            if (destList.Find(p => p.FriendlyName == StringName.Text && p != currentString) != null)
            {
                MessageBox.Show("There is a conflicting name in the connection string list.");
                return;
            }

            currentString.FriendlyName = StringName.Text;
            currentString.ServerType = (ServerType)Enum.Parse(typeof(ServerType), ServerType.Text);
            currentString.String = ConnString.Text;

            if (list != destList)
            {
                list.Remove(currentString);
                destList.Add(currentString);
            }

            updateList();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            globalList.Save();
            Project.ConnectionStrings = projectList.Clone();

            this.Close();
        }
    }
}