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
using EX = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ColdPlace.Inquiry
{
    public partial class QueryForm
    {
        Schema.Database SchemaDatabase = null;
        Schema.Table SchemaTable = null;

        void ResetSchemata()
        {
            SchemaView.BeginUpdate();
            SchemaView.Items.Clear();

            SchemaView.EndUpdate();
        }

        void SchemaView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = SchemaView.SelectedItems[0];

            if (SchemaDatabase == null)
            {
                SchemaDatabase = (Schema.Database)lvi.Tag;
            }
            else if (SchemaTable == null)
            {
                SchemaTable = (Schema.Table)lvi.Tag;
            }

            RefreshSchemaButton_Click(this, new EventArgs());
        }

        private void ParentSchemaButton_Click(object sender, EventArgs e)
        {
            if (SchemaTable != null && SchemaDatabase != null)
                SchemaTable = null;
            else if (SchemaDatabase != null)
            {
                SchemaDatabase = null;
                SchemaTable = null;
            }

            RefreshSchemaButton_Click(this, new EventArgs());
        }

        private void RefreshSchemaButton_Click(object sender, EventArgs e)
        {
            if (ConnectionString == null)
            {
                MessageBox.Show("No database selected. Make sure you've added one to Options -> Connection Strings, and then assign it to this query in the Settings tab.");
                return;
            }

            if (SchemaDatabase == null)
                RefreshDatabases();
            else if (SchemaTable == null)
                RefreshTables();
            else
                RefreshColumns();
        }

        void RefreshDatabases()
        {
            Dal dal = null;
            try
            {
                dal = Dal.Create(ConnectionString);

                List<Schema.Database> databases = dal.SchemaDatabases();

                SchemaView.BeginUpdate();
                SchemaView.Clear();
                SchemaView.Columns.Add(new ColumnHeader()
                {
                    Text = "Database name",
                    Width = 350
                });

                foreach (Schema.Database database in databases)
                    SchemaView.Items.Add(new ListViewItem()
                    {
                        Text = database.Name,
                        Tag = database
                    });

                SchemaView.EndUpdate();
            }
            finally
            {
                if (dal != null) dal.Close();
                dal = null;
            }
            //if (ConnectionString.ServerType == ServerType.MySQL && (db == "information_schema" || db == "dbo"))
        }

        void RefreshTables()
        {
            Dal dal = null;
            try
            {
                dal = Dal.Create(ConnectionString);

                List<Schema.Table> tables = dal.SchemaTables(SchemaDatabase.Name);

                SchemaView.BeginUpdate();
                SchemaView.Clear();
                SchemaView.Columns.Add(new ColumnHeader()
                {
                    Text = "Table name",
                    Width = 350
                });
                SchemaView.Columns.Add(new ColumnHeader()
                {
                    Text = "Type",
                    Width = 150
                });

                foreach (Schema.Table table in tables)
                {
                    ListViewItem lvi = new ListViewItem()
                    {
                        Text = table.Name,
                        Tag = table
                    };
                    lvi.SubItems.Add(table.Type);
                    SchemaView.Items.Add(lvi);
                }

                SchemaView.EndUpdate();
            }
            finally
            {
                if (dal != null) dal.Close();
                dal = null;
            }
        }

        void RefreshColumns()
        {
            Dal dal = null;
            try
            {
                dal = Dal.Create(ConnectionString);

                List<Schema.Column> columns = dal.SchemaColumns(SchemaDatabase.Name, SchemaTable.Name, SchemaTable.Type);

                SchemaView.BeginUpdate();
                SchemaView.Clear();
                SchemaView.Columns.Add(new ColumnHeader()
                {
                    Text = "Column name",
                    Width = 350
                });
                SchemaView.Columns.Add(new ColumnHeader()
                {
                    Text = "Data type",
                    Width = 150
                });
                SchemaView.Columns.Add(new ColumnHeader()
                {
                    Text = "Nullable",
                    Width = 150
                });

                foreach (Schema.Column column in columns)
                {
                    ListViewItem lvi = new ListViewItem()
                    {
                        Text = column.Name,
                        Tag = column
                    };
                    lvi.SubItems.Add(column.Type);
                    lvi.SubItems.Add(column.Null);
                    SchemaView.Items.Add(lvi);
                }

                SchemaView.EndUpdate();
            }
            finally
            {
                if (dal != null) dal.Close();
                dal = null;
            }
        }

        private void RawSchemaSearch_Click(object sender, EventArgs e)
        {
            if (ConnectionString == null)
                return;

            Dal dal = null;
            try
            {
                List<string> restrictions = BuildRawSchemaRestrictions();

                dal = Dal.Create(ConnectionString);

                if (restrictions.Count == 0)
                    RawSchemaView.DataSource = dal.Connection.GetSchema(RawSchemaTypeText.Text);
                else
                    RawSchemaView.DataSource = dal.Connection.GetSchema(RawSchemaTypeText.Text, restrictions.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error querying schema information:\n\n" + ex.Message);
            }
            finally
            {
                if (dal != null) dal.Close();
                dal = null;
            }
        }

        List<string> BuildRawSchemaRestrictions()
        {
            List<string> ret = new List<string>();

            ret.Add(string.IsNullOrEmpty(RawSchemaRestraint1Text.Text) ? null : RawSchemaRestraint1Text.Text);
            ret.Add(string.IsNullOrEmpty(RawSchemaRestraint2Text.Text) ? null : RawSchemaRestraint2Text.Text);
            ret.Add(string.IsNullOrEmpty(RawSchemaRestraint3Text.Text) ? null : RawSchemaRestraint3Text.Text);
            ret.Add(string.IsNullOrEmpty(RawSchemaRestraint4Text.Text) ? null : RawSchemaRestraint4Text.Text);

            while (ret.Count > 0)
            {
                if (ret[ret.Count - 1] == null)
                    ret.RemoveAt(ret.Count - 1);
                else
                    break;
            }

            return ret;
        }


    }
}
