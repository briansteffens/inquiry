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
    public partial class CodeWindow : Form
    {
        string CodeText;

        public CodeWindow(string code)
        {
            InitializeComponent();

            CodeText = code;
        }

        private void CodeWindow_Load(object sender, EventArgs e)
        {
            Code.ConfigurationManager.Language = "cs";
            Code.Margins[0].Width = 20;

            Code.Text = CodeText;
        }
    }
}
