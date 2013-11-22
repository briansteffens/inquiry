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
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchResults.BeginUpdate();
            SearchResults.Items.Clear();

            Dictionary<Query, int> results = new Dictionary<Query, int>();


            foreach (Query query in Project.GetSubQueries(Project.Root))
            {
                int matches = 0;

                if (SearchNameCheck.Checked)
                    matches += Regex.Matches(query.Name ?? "", SearchText.Text, RegexOptions.IgnoreCase).Count;

                if (SearchQueryCheck.Checked)
                    matches += Regex.Matches(query.QueryText ?? "", SearchText.Text, RegexOptions.IgnoreCase).Count;

                if (SearchDescriptionCheck.Checked)
                    matches += Regex.Matches(query.Description ?? "", SearchText.Text, RegexOptions.IgnoreCase).Count;

                if (matches > 0)
                    results.Add(query, matches);
            }


            while (results.Count > 0)
            {
                Query highest = null;

                foreach (Query query in results.Keys)
                    if (highest == null || results[query] > results[highest])
                        highest = query;

                ListViewItem lvi = new ListViewItem(highest.Name);
                lvi.SubItems.Add(results[highest].ToString());
                lvi.Tag = highest;
                SearchResults.Items.Add(lvi);

                results.Remove(highest);
            }

            SearchResults.EndUpdate();
        }

        void SearchResults_DoubleClick(object sender, EventArgs e)
        {
            if (SearchResults.SelectedItems.Count != 1) return;

            Query query = (Query)SearchResults.SelectedItems[0].Tag;
            OpenQuery2(query);
        }
    }
}
