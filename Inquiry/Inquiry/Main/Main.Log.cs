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
        public void Log(string format, params object[] parameters)
        {
            LogPartial(format + "\r\n", parameters);
        }
        public void LogPartial(string format, params object[] parameters)
        {
            string output = string.Format(format, parameters);

            LogText.Text += output;
            LogText.Select(LogText.Text.Length - 1, 0);
            LogText.ScrollToCaret();
        }
    }
}
