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
    public partial class Main : Form
    {
        public string ProjectFilename { get; set; }

        public Config config = new Config();
        public ExtensionList Extensions = new ExtensionList();

        QueryProject m_Project = null;
        public QueryProject Project
        {
            get
            {
                return m_Project;
            }
            set
            {
                bool changed = (m_Project != value);
                m_Project = value;
                if (changed)
                {
                    m_Project.DirtyChanged += new EventHandler(m_Project_DirtyChanged);
                    updateTree();
                }
            }
        }

        public Main()
        {
            InitializeComponent();
            ProjectFilename = null;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Project = new QueryProject();
            Project.Dirty = false;

            FormClosing += new FormClosingEventHandler(Main_FormClosing);

            QueryTree.MouseUp += new MouseEventHandler(QueryTree_MouseUp);
            QueryTree.MouseDown += new MouseEventHandler(QueryTree_MouseDown);
            QueryTree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(QueryTree_NodeMouseDoubleClick);
            QueryTree.ItemDrag += new ItemDragEventHandler(QueryTree_ItemDrag);
            QueryTree.DragEnter += new DragEventHandler(QueryTree_DragEnter);
            QueryTree.DragDrop += new DragEventHandler(QueryTree_DragDrop);
            QueryTree.AfterLabelEdit += new NodeLabelEditEventHandler(QueryTree_AfterLabelEdit);
            QueryTree.AfterExpand += new TreeViewEventHandler(QueryTree_AfterExpand);

            SearchResults.DoubleClick += new EventHandler(SearchResults_DoubleClick);

            panel1.Width = config.LeftPaneWidth;

            this.Text = "Inquiry";

            if (config.WindowLeft != 0 && config.WindowState != FormWindowState.Maximized)
            {
                Left = config.WindowLeft;
                Top = config.WindowTop;
                Width = config.WindowWidth;
                Height = config.WindowHeight;
            }
            WindowState = config.WindowState;
            
            reloadProjectList();
            updateValueSetList();
        }





        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CloseProject();

            if (!e.Cancel)
            {
                config.LeftPaneWidth = panel1.Width;

                config.WindowLeft = Left;
                config.WindowTop = Top;
                config.WindowWidth = Width;
                config.WindowHeight = Height;
                config.WindowState = WindowState;

                config.Save();
            }
        }






        
        private void editConnectionStringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionStringManager dialog = new ConnectionStringManager(Project);
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            foreach (Form childForm in MdiChildren)
            {
                if (!(childForm is QueryForm))
                    continue;

                QueryForm form = (QueryForm)childForm;
                form.ReloadConnectionStringList();
            }
        }

        private void projectListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectListManager dialog = new ProjectListManager(config);
            if (DialogResult.OK != dialog.ShowDialog(this))
                return;

            reloadProjectList();
        }

        void reloadProjectList()
        {
            ProjectMenuItem.DropDownItems.Clear();

            CommonProjectList list = new CommonProjectList();
            foreach (CommonProject project in list)
            {
                ToolStripItem item = new ToolStripMenuItem(project.Name);
                item.Tag = project;
                item.Click += new EventHandler(item_Click);
                ProjectMenuItem.DropDownItems.Add(item);
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            CommonProject project = (CommonProject)((ToolStripItem)sender).Tag;

            if (!CloseProject())
                return;

            foreach (Form child in MdiChildren)
                child.Close();

            Project = new QueryProject();
            Project.Load(project.Path);
            ProjectFilename = project.Path;

            UpdateParameterList();

            updateTree();
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Options dialog = new Options(config);
            if (DialogResult.OK != dialog.ShowDialog(this))
                return;
        }

        private void codeExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeExport dialog = new CodeExport(this);
            dialog.RunExport();
        }

        private void aboutInquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About dialog = new About();
            dialog.ShowDialog(this);
        }

        private void codeExportSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeExport dialog = new CodeExport(this);
            dialog.ShowDialog(this);
        }

        private void extensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtensionManager dialog = new ExtensionManager();
            if (DialogResult.OK != dialog.ShowDialog(this))
                return;


        }
        

        bool m_FullScreenMode = false;
        public bool FullScreenMode
        {
            get
            {
                return m_FullScreenMode;
            }
            set
            {
                if (m_FullScreenMode == value)
                    return;

                m_FullScreenMode = value;

                menuStrip.Visible = !m_FullScreenMode;
                panel1.Visible = !m_FullScreenMode;
                splitter1.Visible = !m_FullScreenMode;
            }
        }
        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FullScreenMode = !FullScreenMode;

            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild is QueryForm)
                    ((QueryForm)ActiveMdiChild).IsFullScreen = FullScreenMode;
                
                if (FullScreenMode)
                    ActiveMdiChild.WindowState = FormWindowState.Maximized;
            }
        }
    }
}