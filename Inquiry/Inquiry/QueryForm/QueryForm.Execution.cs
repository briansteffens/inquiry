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
    public partial class QueryForm
    {
        Thread queryThread = null;

        private void SafeQueryMode_Click(object sender, EventArgs e)
        {
            Query.SafeMode = SafeQueryMode.Checked;
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (ConnectionString == null)
            {
                MessageBox.Show("No database selected. Make sure you've added one to Options -> Connection Strings, and then assign it to this query in the Settings tab.");
                return;
            }

            RunQuery();
        }

        void RunQuery()
        {
            if (queryThread != null)
                return;

            QueryProgress.Visible = true;

            string query = QueryText.Text;
            Dictionary<string, string> parameters = ParentForm.Project.GetParameters();
            foreach (string key in parameters.Keys)
                query = query.Replace("{!" + key + "}", parameters[key]);

            FinalQueryText.Text = query;

            ExecuteParameters ep = new ExecuteParameters()
            {
                SafeMode = SafeQueryMode.Checked,
                Query = query,
                ReturnInvokeTarget = this,
                ConnectionString = ConnectionString
            };


            ParameterizedThreadStart start = new ParameterizedThreadStart(Execute);
            queryThread = new Thread(start);
            queryThread.Start(ep);
        }
        void Execute(object obj_ep)
        {
            ExecuteParameters ep = (ExecuteParameters)obj_ep;

            Dal dal = null;
            try
            {
                dal = Dal.Create(ep.ConnectionString);


                if (ep.SafeMode)
                    dal.BeginTransaction();


                int recordsAffected = 0;
                DataTable[] dts = dal.ReadTables(ep.Query, out recordsAffected);


                if (ep.SafeMode)
                {
                    if (DialogResult.Yes != MessageBox.Show(null, "This query has affected " + recordsAffected.ToString() + " records within a transaction.\r\n\r\nCommit the changes?", "Safe Query Mode Confirmation", MessageBoxButtons.YesNoCancel))
                    {
                        dal.RollbackTransaction();

                        ep.OutputText = "Transaction rolled back - no changes persisted from the previous run.";
                        ep.SelectTab = "Output";

                        ep.Success = false;

                        if (ep.ReturnInvokeTarget.InvokeRequired)
                        {
                            ExecuteFinishedDelegate del = ExecuteFinished;
                            ep.ReturnInvokeTarget.Invoke(del, ep);
                        }
                        else
                            ExecuteFinished(ep);
                        
                        return;
                    }

                    dal.CommitTransaction();
                }


                ep.OutputText = "Records affected: " + recordsAffected.ToString();
                ep.RecordCount = "";


                if (dts != null)
                {
                    ep.Results = dts;
                    ep.SelectTab = "Results";

                    int recordCount = 0;
                    foreach (DataTable dt in dts)
                        recordCount += dt.Rows.Count;
                    ep.RecordCount = recordCount.ToString();
                }
                else
                {
                    ep.SelectTab = "Output";
                }
            }
            catch (Exception ex)
            {
                ep.SelectTab = "Output";
                ep.OutputText = ex.Message;
            }
            finally
            {
                if (dal != null) dal.Close();
                dal = null;
            }


            if (ep.ReturnInvokeTarget.InvokeRequired)
            {
                ExecuteFinishedDelegate del = ExecuteFinished;
                ep.ReturnInvokeTarget.Invoke(del, ep);
            }
            else
                ExecuteFinished(ep);
        }

        delegate void ExecuteFinishedDelegate(ExecuteParameters ep);
        void ExecuteFinished(ExecuteParameters ep)
        {
            if (!ep.Success)
                return;

            OutputText.Text = ep.OutputText;
            ResultsTabs.SelectedTab = ResultsTabs.TabPages[ep.SelectTab];
            RecordCount.Text = ep.RecordCount;

            ResultSetTabs.TabPages.Clear();
            if (ep.Results != null)
                for (int i = 0; i < ep.Results.Length; i++)
                {
                    DataTable dt = ep.Results[i];
                    ResultSetTabs.TabPages.Add(i.ToString(), (i + 1).ToString());
                    TabPage tab = ResultSetTabs.TabPages[i.ToString()];

                    DataGridView view = new DataGridView();
                    view.DataSource = dt;
                    view.SelectionChanged += new EventHandler(ResultsView_SelectionChanged);
                    view.Dock = DockStyle.Fill;
                    tab.Controls.Add(view);
                }

            QueryProgress.Visible = false;

            queryThread = null;
        }
    }

    class ExecuteParameters
    {
        // Input parameters
        public bool SafeMode { get; set; }
        public string Query { get; set; }
        public Control ReturnInvokeTarget { get; set; }
        public ConnectionString ConnectionString { get; set; }

        // Output parameters
        public bool Success { get; set; }
        public string OutputText { get; set; }
        public string SelectTab { get; set; }
        public string RecordCount { get; set; }
        public DataTable[] Results { get; set; }

        public ExecuteParameters()
        {
            Success = true;
        }
    }
}
