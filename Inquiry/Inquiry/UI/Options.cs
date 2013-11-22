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
    public partial class Options : Form
    {

        #region General

        Config config;

        public Options(Config config)
        {
            InitializeComponent();

            this.config = config;
        }

        private void Options_Load(object sender, EventArgs e)
        {
            ProjectsProjectPath.Text = config.ProjectPath;
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            config.ProjectPath = ProjectsProjectPath.Text;
            
            config.Save();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Projects

        private void ProjectsProjectPathBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (DialogResult.OK != dialog.ShowDialog(this))
                return;

            ProjectsProjectPath.Text = dialog.SelectedPath;
        }

        #endregion

    }
}
