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
    public partial class ProjectListManager : Form
    {
        CommonProjectList list = new CommonProjectList();
        CommonProject currentProject = null;
        Config config;

        public ProjectListManager(Config config)
        {
            InitializeComponent();

            this.config = config;
        }

        private void ProjectListManager_Load(object sender, EventArgs e)
        {
            updateList();
        }

        void updateList()
        {
            ProjectList.BeginUpdate();
            ProjectList.Items.Clear();

            foreach (CommonProject project in list)
            {
                ListViewItem lvi = new ListViewItem(project.Name);
                
                lvi.SubItems.Add(project.Path);
                lvi.Tag = project;

                ProjectList.Items.Add(lvi);
            }

            ProjectList.EndUpdate();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            CommonProject project = new CommonProject();

            project.Name = "New Project";
            int i = 1;
            while (list.Find(p => p.Name == project.Name) != null)
            {
                i++;
                project.Name = "New Project " + i.ToString();
            }

            project.Path = "";

            list.Add(project);
            updateList();

            editProject(project);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ProjectList.SelectedItems.Count != 1)
                return;

            CommonProject project = (CommonProject)ProjectList.SelectedItems[0].Tag;
            list.Remove(project);

            updateList();
            ProjectList_SelectedIndexChanged(this, new EventArgs());
        }

        void editProject(CommonProject project)
        {
            if (currentProject == project)
                return;

            currentProject = project;

            NameText.Text = currentProject.Name;
            FileText.Text = currentProject.Path;

            bool setSelection = ProjectList.SelectedItems.Count != 1 || ProjectList.SelectedItems[0].Tag != project;

            if (setSelection)
                foreach (ListViewItem lvi in ProjectList.Items)
                    lvi.Selected = (lvi.Tag == project);
        }

        private void ProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditGroup.Enabled = (ProjectList.SelectedItems.Count == 1);
            if (!EditGroup.Enabled)
            {
                NameText.Text = "";
                FileText.Text = "";

                currentProject = null;

                return;
            }

            CommonProject project = (CommonProject)ProjectList.SelectedItems[0].Tag;
            editProject(project);
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (ProjectList.SelectedItems.Count != 1) return;

            CommonProject project = (CommonProject)ProjectList.SelectedItems[0].Tag;

            int index = list.IndexOf(project);

            index--;
            if (index < 0) index = 0;

            list.Remove(project);
            list.Insert(index, project);

            updateList();
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (ProjectList.SelectedItems.Count != 1) return;

            CommonProject project = (CommonProject)ProjectList.SelectedItems[0].Tag;

            int index = list.IndexOf(project);

            index++;
            if (index > list.Count - 1) index = list.Count - 1;

            list.Remove(project);
            list.Insert(index, project);

            updateList();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = config.ProjectPath;
            openFileDialog.Filter = "Query Projects (*.queryproject)|*.queryproject|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            FileText.Text = openFileDialog.FileName;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (list.Find(p => p.Name == NameText.Text && p != currentProject) != null)
            {
                MessageBox.Show("There is a conflicting project name.");
                return;
            }

            currentProject.Name = NameText.Text;
            currentProject.Path = FileText.Text;

            updateList();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            list.Save();

            this.Close();
        }
    }
}
