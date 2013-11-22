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
    public partial class CodeExport : Form
    {
        public CodeExporter Exporter { get; set; }
        public CodeExportParams Params { get; set; }
        Main parentForm;
        QueryProject project;


        public static void ConfigureParams(GroupBox group, CodeExportParams p)
        {
            CodeExportSettings settings = new CodeExportSettings();

            group.Controls.Clear();

            PropertyInfo[] pis = p.GetType().GetProperties();
            int i = -1;
            foreach (PropertyInfo pi in pis)
            {
                object[] obj_attrs = pi.GetCustomAttributes(typeof(CodeExportFieldAttribute), false);
                if (obj_attrs == null || obj_attrs.Length != 1 || !(obj_attrs[0] is CodeExportFieldAttribute))
                    continue;
                CodeExportFieldAttribute attr = (CodeExportFieldAttribute)obj_attrs[0];

                i++;

                Label label = new Label()
                {
                    Text = attr.UiName,
                    Location = new Point(15, (i * 24) + 18),
                    Width = 200,
                    Height = 22,
                    TextAlign = ContentAlignment.MiddleRight
                };
                group.Controls.Add(label);

                if (pi.PropertyType == typeof(string))
                {
                    TextBox text = new TextBox()
                    {
                        Name = pi.Name,
                        Tag = pi,
                        Height = 22,
                        Location = new Point(225, (i * 24) + 18),
                        Width = group.Width - 235,
                        Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right
                    };

                    object val = pi.GetValue(p, null);
                    text.Text = val == null ? "" : val.ToString();

                    group.Controls.Add(text);


                    if (settings.Params.ContainsKey(attr.UiName))
                        text.Text = settings.Params[attr.UiName];


                    continue;
                }
            }
        }

        public static void SaveParams(GroupBox group, CodeExportParams p)
        {
            PropertyInfo[] pis = p.GetType().GetProperties();
            int i = -1;
            foreach (PropertyInfo pi in pis)
            {
                i++;

                Control control = null;
                foreach (Control ctrl in group.Controls)
                    if (ctrl.Name == pi.Name)
                    {
                        control = ctrl;
                        break;
                    }
                if (control == null)
                    throw new ArgumentException("Control not found");


                if (pi.PropertyType == typeof(string))
                {
                    pi.SetValue(p, control.Text, null);

                    continue;
                }
            }
        }

        public void RunExport()
        {
            CodeExportSettings settings = new CodeExportSettings();
            
            CodeExporter exporter = null;
            foreach (Extension extension in parentForm.Extensions)
            {
                Assembly temp_asm = extension.Assembly;

                foreach (CodeExporter exp in extension.CodeExporters)
                    if (exp.CodeExporterAttribute.Language == settings.Language)
                    {
                        exporter = exp;
                        break;
                    }

                if (exporter != null) 
                    break;
            }

            if (exporter == null)
            {
                MessageBox.Show("Code exporter " + settings.Language + " was not found.");
                return;
            }


            CodeExportParams parameters = exporter.CreateParams();

            PropertyInfo[] pis = parameters.GetType().GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                object[] obj_attrs = pi.GetCustomAttributes(typeof(CodeExportFieldAttribute), false);
                if (obj_attrs == null || obj_attrs.Length != 1 || !(obj_attrs[0] is CodeExportFieldAttribute))
                    continue;
                CodeExportFieldAttribute attr = (CodeExportFieldAttribute)obj_attrs[0];

                if (!settings.Params.ContainsKey(attr.UiName))
                {
                    MessageBox.Show(attr.UiName + " was not found in code export settings.");
                    return;
                }

                if (pi.PropertyType == typeof(string))
                {
                    pi.SetValue(parameters, settings.Params[attr.UiName], null);
                    continue;
                }
            }


            string code = exporter.Export(parentForm.Project, parameters);


            if (settings.ExportTo == "Code window")
            {
                CodeWindow codeWindow = new CodeWindow(code);
                codeWindow.MdiParent = parentForm;
                codeWindow.Show();
            }
            else if (settings.ExportTo == "File")
            {
                System.IO.File.WriteAllText(settings.ExportFile, code);
            }
        }


        public CodeExport(Main parentform)
        {
            InitializeComponent();

            this.parentForm = parentform;
            this.project = parentForm.Project;
        }

        private void CodeExport_Load(object sender, EventArgs e)
        {
            updateLanguageList();
            updateValueSetList();

            CodeExportSettings settings = new CodeExportSettings();
            try
            {
                LanguageCombo.Text = settings.Language;
            }
            catch
            {
            }
            LanguageCombo_SelectedIndexChanged(this, new EventArgs());

            try
            {
                ValueSetCombo.Text = settings.ValueSet;
            }
            catch
            {
            }

            ExportToCombo.Text = settings.ExportTo;
            ExportFileText.Text = settings.ExportFile;
        }

        void updateLanguageList()
        {
            LanguageCombo.BeginUpdate();
            LanguageCombo.Items.Clear();

            foreach (Extension extension in parentForm.Extensions)
            {
                Assembly temp_asm = extension.Assembly;

                foreach (CodeExporter exporter in extension.CodeExporters)
                    LanguageCombo.Items.Add(exporter);
            }

            LanguageCombo.EndUpdate();

            if (LanguageCombo.Items.Count == 0)
            {
                MessageBox.Show("No code exporters loaded. Add them through Options -> Manage Extensions.");
                this.Close();
                return;
            }
        }

        void updateValueSetList()
        {
            ValueSetCombo.BeginUpdate();
            ValueSetCombo.Items.Clear();

            foreach (ValueSet vs in parentForm.Project.ValueSets)
                ValueSetCombo.Items.Add(vs);

            ValueSetCombo.EndUpdate();
        }

        private void LanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguageCombo.SelectedItem == null)
                Exporter = null;
            else
                Exporter = (CodeExporter)LanguageCombo.SelectedItem;

            if (Exporter == null)
            {
                SettingsGroup.Controls.Clear();
                Params = null;
                return;
            }

            Params = Exporter.CreateParams();

            CodeExport.ConfigureParams(SettingsGroup, Params);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            CodeExportSettings settings = new CodeExportSettings();

            settings.Language = LanguageCombo.Text;
            settings.ValueSet = ValueSetCombo.Text;
            settings.ExportTo = ExportToCombo.Text;
            settings.ExportFile = ExportFileText.Text;

            settings.Params.Clear();

            foreach (Control control in SettingsGroup.Controls)
            {
                if (control is TextBox)
                {
                    PropertyInfo pi = (PropertyInfo)control.Tag;

                    object[] obj_attrs = pi.GetCustomAttributes(typeof(CodeExportFieldAttribute), false);
                    if (obj_attrs == null || obj_attrs.Length != 1 || !(obj_attrs[0] is CodeExportFieldAttribute))
                        continue;
                    CodeExportFieldAttribute attr = (CodeExportFieldAttribute)obj_attrs[0];

                    settings.Params.Add(attr.UiName, control.Text);

                    continue;
                }
            }

            settings.Save();
            this.Close();
        }

        private void ExportFileBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            if (DialogResult.OK != dialog.ShowDialog(this))
                return;

            ExportFileText.Text = dialog.FileName;
        }
    }
}