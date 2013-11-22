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
        #region Parameters

        void updateValueSetList()
        {
            string temp = Project.CurrentValueSet.Name;

            ValueSetCombo.BeginUpdate();
            ValueSetCombo.Items.Clear();

            foreach (ValueSet vs in Project.ValueSets)
                ValueSetCombo.Items.Add(vs.Name);

            ValueSetCombo.EndUpdate();


            ValueSetCombo.Text = Project.CurrentValueSet.Name;

            UpdateParameterList();
        }

        private void ValueSetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project.CurrentValueSetName = ValueSetCombo.Text;
            RenameValueSet.Text = ValueSetCombo.Text;

            UpdateParameterList();
        }

        private void AddValueSetButton_Click(object sender, EventArgs e)
        {
            string name = "New value set";
            int i = 1;
            while (Project.ValueSets.Find(p => p.Name == name) != null)
            {
                i++;
                name = "New value set " + i.ToString();
            }

            ValueSet vs = new ValueSet();
            vs.Name = name;

            if (Project.ValueSets.Count > 0)
                foreach (string key in Project.ValueSets[0].Parameters.Keys)
                    vs.Parameters.Add(key, "");

            Project.ValueSets.Add(vs);
            Project.CurrentValueSetName = vs.Name;

            updateValueSetList();
        }

        private void DeleteValueSetButton_Click(object sender, EventArgs e)
        {
            if (ValueSetCombo.Items.Count == 0) return;

            Project.ValueSets.Remove(Project.CurrentValueSet);
            Project.CurrentValueSetName = null;

            updateValueSetList();
        }

        private void RenameValueSetButton_Click(object sender, EventArgs e)
        {
            if (ValueSetCombo.Items.Count == 0) return;

            if (RenameValueSet.Text == Project.CurrentValueSet.Name)
                return;

            Project.CurrentValueSet.Name = RenameValueSet.Text;
            Project.CurrentValueSetName = RenameValueSet.Text;

            updateValueSetList();
        }


        string selectedParameter = null;

        void UpdateParameterList()
        {
            ParameterList.BeginUpdate();
            ParameterList.Items.Clear();

            Dictionary<string, string> parameters = Project.GetParameters();
            foreach (string key in parameters.Keys)
            {
                ListViewItem lvi = new ListViewItem(key);
                lvi.SubItems.Add(parameters[key]);
                ParameterList.Items.Add(lvi);
            }

            ParameterList.EndUpdate();

            ParameterList_SelectedIndexChanged(this, new EventArgs());
        }

        private void ParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ParameterList.SelectedItems.Count == 0)
            {
                selectedParameter = null;
                ParameterName.Text = "";
                ParameterValue.Text = "";
                EditGroup.Enabled = false;
                return;
            }

            selectedParameter = ParameterList.SelectedItems[0].Text;
            ParameterName.Text = selectedParameter;
            ParameterValue.Text = Project.GetParameter(selectedParameter);
            EditGroup.Enabled = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string key = "New Parameter 1";
            int i = 1;
            while (Project.ParameterExists(key))
            {
                i++;
                key = "New Parameter " + i.ToString();
            }

            Project.AddParameter(key);
            UpdateParameterList();

            foreach (ListViewItem lvi in ParameterList.Items)
                lvi.Selected = (lvi.Text == key);

            ParameterList_SelectedIndexChanged(this, new EventArgs());
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedParameter == null)
                return;

            Project.RemoveParameter(selectedParameter);

            UpdateParameterList();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (selectedParameter == null)
                return;

            if (ParameterName.Text != selectedParameter)
            {
                if (Project.ParameterExists(ParameterName.Text))
                {
                    MessageBox.Show("Parameter name already exists.");
                    return;
                }

                Project.RemoveParameter(selectedParameter);
                Project.AddParameter(ParameterName.Text);
            }

            Project.SetParameter(ParameterName.Text, ParameterValue.Text);

            UpdateParameterList();

            selectedParameter = ParameterName.Text;

            foreach (ListViewItem lvi in ParameterList.Items)
                lvi.Selected = (lvi.Text == selectedParameter);

            ParameterList_SelectedIndexChanged(this, new EventArgs());
        }

        #endregion


    }
}
