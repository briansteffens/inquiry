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
        void ReloadTextProcessorList()
        {
            TextProcessorList.BeginUpdate();
            TextProcessorList.Items.Clear();

            ExtensionList list = ((Main)MdiParent).Extensions;
            foreach (Extension extension in list)
            {
                Assembly temp_asm = extension.Assembly;

                foreach (Processor processor in extension.Processors)
                    TextProcessorList.Items.Add(new ListViewItem(processor.ProcessorAttribute.UiName)
                    {
                        Tag = processor.GetType()
                    });
            }

            TextProcessorList.EndUpdate();
        }

        Type TextProcessorType = null;
        Processor TextProcessor = null;

        void TextProcessorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TextProcessorList.SelectedItems.Count != 1)
            {
                TextProcessorType = null;
                TextProcessor = null;
                TextProcessorDescription.Text = "";
                return;
            }

            TextProcessorType = (Type)TextProcessorList.SelectedItems[0].Tag;
            TextProcessor = (Processor)Activator.CreateInstance(TextProcessorType);
            TextProcessorDescription.Text = TextProcessor.ProcessorAttribute.Description ?? "";

            ProcessorUI.ConfigureParams(TextProcessorParams, TextProcessor);
        }

        private void Process_Click(object sender, EventArgs e)
        {
            if (TextProcessor == null) return;

            ProcessorUI.SaveParams(TextProcessorParams, TextProcessor);

            if (!TextProcessor.GetType().IsSubclassOf(typeof(LineProcessor)))
            {
                QueryText.Text = TextProcessor.Process(QueryText.Text);
                return;
            }


            string[] lines = QueryText.Text.Split(new string[] { TextProcessor.NewlineStringConstant }, StringSplitOptions.None);

            StringBuilder sb = new StringBuilder();
            bool first = true;

            foreach (string line in lines)
            {
                if (!first) sb.Append(TextProcessor.NewlineStringConstant);

                sb.Append(TextProcessor.Process(line));

                first = first ? !first : first;
            }

            QueryText.Text = sb.ToString();
        }
    }
}
