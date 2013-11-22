using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace ColdPlace.Inquiry
{
    public partial class ExtensionManager : Form
    {
        ExtensionList list = new ExtensionList();

        public ExtensionManager()
        {
            InitializeComponent();
        }

        private void ExtensionManager_Load(object sender, EventArgs e)
        {
            updateList();
        }

        void updateList()
        {
            List.BeginUpdate();
            List.Items.Clear();

            foreach (Extension ext in list)
            {
                ListViewItem lvi = new ListViewItem(ext.Path);
                lvi.Tag = ext;
                List.Items.Add(lvi);
            }

            List.EndUpdate();
        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            InfoGroup.Enabled = (List.SelectedItems.Count == 1);
            if (!InfoGroup.Enabled)
            {
                Info.Text = "";
                return;
            }

            Extension ext = (Extension)List.SelectedItems[0].Tag;
            Assembly tempAssembly = ext.Assembly;

            StringBuilder sb = new StringBuilder("Extension " + ext.Path + "\r\n\r\n");

            sb.Append("\t" + ext.Processors.Count.ToString() + " text processors:\r\n");
            foreach (Processor p in ext.Processors)
                sb.Append("\t- " + p.ProcessorAttribute.UiName + "\r\n");

            sb.Append("\r\n\t" + ext.CodeExporters.Count.ToString() + " code exporters:\r\n");
            foreach (CodeExporter exp in ext.CodeExporters)
                sb.Append("\t- " + exp.CodeExporterAttribute.Language + "\r\n");

            Info.Text = sb.ToString();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*";
            if (DialogResult.OK != dialog.ShowDialog(this))
                return;

            if (list.Find(p => p.Path == dialog.FileName) != null)
            {
                MessageBox.Show("Extension already loaded.");
                return;
            }

            Extension ext = new Extension();
            ext.Path = dialog.FileName;
            list.Add(ext);

            updateList();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (List.SelectedItems.Count != 1) return;
            Extension ext = (Extension)List.SelectedItems[0].Tag;

            list.Remove(ext);

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