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
        void m_Project_DirtyChanged(object sender, EventArgs e)
        {
            this.Text = "Inquiry " + (Project.Dirty ? "*" : "");
        }

        bool CloseProject()
        {
            if (Project.Dirty)
            {
                DialogResult result = MessageBox.Show(this, "Save changes first?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return false;

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (ProjectFilename == null)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.InitialDirectory = config.ProjectPath;
                        saveFileDialog.Filter = "Query Projects (*.queryproject)|*.queryproject|All Files (*.*)|*.*";
                        if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                            return false;

                        Project.Save(saveFileDialog.FileName);
                        ProjectFilename = saveFileDialog.FileName;
                    }
                    else
                    {
                        Project.Save(ProjectFilename);
                    }
                }
            }

            return true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseProject())
                return;

            foreach (Form child in MdiChildren)
                child.Close();

            Project = new QueryProject();
            Project.Dirty = false;
            ProjectFilename = null;

            updateTree();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            if (!CloseProject())
                return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = config.ProjectPath;
            openFileDialog.Filter = "Query Projects (*.queryproject)|*.queryproject|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            foreach (Form child in MdiChildren)
                child.Close();

            Project = new QueryProject();
            Project.Load(openFileDialog.FileName);
            ProjectFilename = openFileDialog.FileName;

            UpdateParameterList();

            updateTree();
            updateValueSetList();
            UpdateParameterList();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProjectFilename == null)
            {
                SaveAsToolStripMenuItem_Click(sender, e);
                return;
            }

            Project.Save(ProjectFilename);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = config.ProjectPath;
            saveFileDialog.Filter = "Query Projects (*.queryproject)|*.queryproject|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            Project.Save(saveFileDialog.FileName);
            ProjectFilename = saveFileDialog.FileName;
        }
    }
}
