using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;

namespace ColdPlace.Inquiry
{
    public partial class QueryForm : Form
    {
        public new Main ParentForm { get; set; }
        public Query Query { get; set; }
        public ConnectionString ConnectionString { get; set; }

        bool m_IsFullScreen = false;
        public bool IsFullScreen
        {
            get
            {
                return m_IsFullScreen;
            }
            set
            {
                if (m_IsFullScreen == value)
                    return;

                m_IsFullScreen = value;

                if (m_IsFullScreen)
                {
                    splitContainer2.Panel1.Controls.Remove(QueryText);
                    splitContainer2.Visible = false;
                    this.Controls.Add(QueryText);
                    QueryText.Dock = DockStyle.Fill;
                    toolStrip1.Visible = false;
                }
                else
                {
                    this.Controls.Remove(QueryText);
                    splitContainer2.Visible = true;
                    splitContainer2.Panel1.Controls.Add(QueryText);
                    QueryText.Dock = DockStyle.Fill;
                    toolStrip1.Visible = true;
                }
            }
        }


        public QueryForm()
        {
            InitializeComponent();

            DatabaseCombo.SelectedIndexChanged += new EventHandler(DatabaseCombo_SelectedIndexChanged);
            QueryText.KeyUp += new KeyEventHandler(QueryText_KeyUp);
            QueryText.TextChanged += new EventHandler(QueryText_TextChanged);
            SchemaView.MouseDoubleClick += new MouseEventHandler(SchemaView_MouseDoubleClick);
            DescriptionText.TextChanged += new EventHandler(DescriptionText_TextChanged);
            TextProcessorList.SelectedIndexChanged += new EventHandler(TextProcessorList_SelectedIndexChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResultsTabs.TabPages.Remove(RawSchema);

            ReloadConnectionStringList();

            DescriptionText.Text = Query.Description;

            QueryText.Text = Query.QueryText;
            if (!string.IsNullOrEmpty(Query.DatabaseName))
                foreach (object obj in DatabaseCombo.Items)
                    if (obj.ToString() == Query.DatabaseName)
                    {
                        DatabaseCombo.SelectedItem = obj;
                        break;
                    }

            SafeQueryMode.Checked = Query.SafeMode;

            ReloadTextProcessorList();
        }


        void DescriptionText_TextChanged(object sender, EventArgs e)
        {
            Query.Description = DescriptionText.Text;
        }

        void ResultsView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView ResultsView = (DataGridView)sender;

            if (ResultsView.SelectedCells.Count != 1)
            {
                ValueTextView.Text = "";
                return;
            }

            ValueTextView.Text = ResultsView.SelectedCells[0].Value.ToString();
        }

        void QueryText_TextChanged(object sender, EventArgs e)
        {
            Query.QueryText = QueryText.Text;
        }

        void QueryText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ExecuteButton.Checked = true;
                RunQuery();
                ExecuteButton.Checked = false;
                e.Handled = true;
            }
        }

        void DatabaseCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Query.DatabaseName = DatabaseCombo.SelectedItem.ToString();

            ConnectionStringList list = null;
            string csName = DatabaseCombo.SelectedItem.ToString();

            if (!csName.StartsWith("Project: "))
                list = new ConnectionStringList();
            else
            {
                list = Query.Project.ConnectionStrings;
                csName = csName.Remove(0, 9);
            }

            ConnectionString = list.ByName(csName);
            ServerTypeLabel.Text = ConnectionString.ServerType.ToString();

            Dal dal = null;
            DbDataReader r = null;
            try
            {
                dal = Dal.Create(ConnectionString);
                r = dal.Reader("select 1;");
                r.Read();

                int temp = int.Parse(r[0].ToString());
                if (temp != 1) throw new ArgumentException("Test query failed.");

                OutputText.Text = "Database connection test succeeded.";
            }
            catch (Exception ex)
            {
                OutputText.Text = "Database connection test failed:\r\n" + ex.Message;
            }
            finally
            {
                if (r != null) r.Dispose();
                r = null;

                if (dal != null) dal.Close();
                dal = null;
            }

            SchemaTable = null;
            SchemaDatabase = null;
        }

        
        public void ReloadConnectionStringList()
        {
            string tempSelection = null;
            if (DatabaseCombo.SelectedItem != null)
                tempSelection = DatabaseCombo.SelectedItem.ToString();

            DatabaseCombo.BeginUpdate();
            DatabaseCombo.Items.Clear();

            ConnectionStringList list = new ConnectionStringList();
            foreach (ConnectionString connstr in list)
                DatabaseCombo.Items.Add(connstr.FriendlyName);

            list = Query.Project.ConnectionStrings.Clone();
            foreach (ConnectionString connstr in list)
                DatabaseCombo.Items.Add("Project: " + connstr.FriendlyName);

            DatabaseCombo.EndUpdate();

            if (tempSelection != null)
                foreach (object obj in DatabaseCombo.Items)
                    if (obj.ToString() == tempSelection)
                    {
                        DatabaseCombo.SelectedItem = obj;
                        break;
                    }
        }


        private void DatabaseCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void currentTabToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ResultSetTabs.TabPages.Count == 0)
            {
                MessageBox.Show("Nothing to export.");
                return;
            }

            DataGridView ResultsView = null;
            foreach (Control control in ResultSetTabs.SelectedTab.Controls)
            {
                if (control is DataGridView)
                {
                    ResultsView = (DataGridView)control;
                    break;
                }
            }

            if (ResultsView == null)
                return;

            if (ResultsView.DataSource == null)
            {
                MessageBox.Show("No results to export.");
                return;
            }

            if (!(ResultsView.DataSource is DataTable))
            {
                MessageBox.Show("Invalid results object.");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (dialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;

            DataTable dt = (DataTable)ResultsView.DataSource;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataColumn column = dt.Columns[i];

                if (i != 0)
                    sb.Append(",");

                sb.AppendFormat("\"{0}\"", column.ColumnName.Replace("\"", "\"\""));
            }
            sb.Append("\r\n");

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i != 0)
                        sb.Append(",");

                    object obj_temp = row[i];

                    string str_temp = "";
                    if (obj_temp != null && !(obj_temp is DBNull))
                        str_temp = obj_temp.ToString();

                    sb.AppendFormat("\"{0}\"", str_temp.Replace("\"", "\"\""));
                }
                sb.Append("\r\n");
            }

            System.IO.File.WriteAllText(dialog.FileName, sb.ToString());

            DialogResult result = MessageBox.Show(this, "Data written to file " + dialog.FileName + ".\n\nOpen in default CSV editor?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            System.Diagnostics.Process.Start(dialog.FileName);
        }


    }


}