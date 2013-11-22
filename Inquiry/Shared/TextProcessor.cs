/*
 * This file contains classes necessary for developing text processor extensions and executing text processors in the UI.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace ColdPlace.Inquiry
{
    /// <summary>
    /// Functions for placing text processor custom parameters into the Inquiry UI and then retrieving those values
    /// set by the user and placing them in the processor to be used.
    /// </summary>
    public static class ProcessorUI
    {
        /// <summary>
        /// Adds the parameters required by the given Processor to the GroupBox for entry by the user.
        /// </summary>
        /// <param name="panel">The GroupBox into which the parameters should be placed.</param>
        /// <param name="proc">The Processor whose parameters should be loaded.</param>
        public static void ConfigureParams(GroupBox panel, Processor proc)
        {
            panel.Controls.Clear(); // Clear target control in case it's being reused.

            PropertyInfo[] pis = proc.GetType().GetProperties(); // Get public properties (parameters)
            int i = -1;
            foreach (PropertyInfo pi in pis) // Loop over all public properties
            {
                if (pi.Name == "ProcessorAttribute") // This is built-in to the Processor class and is not a parameter.
                    continue;

                object[] obj_attrs = pi.GetCustomAttributes(typeof(IgnoreAttribute), false);
                if (obj_attrs.Length == 1)
                    continue;
                
                // Increment the iterator. This is used for vertical placement of controls. We don't just use a regular for
                // loop because not all parameters will be used and we'd need a separate iterator anyway.
                i++; 


                // All parameter types need a label to display their name
                Label label = new Label();
                label.Text = pi.Name + ":";
                label.Location = new Point(15, (i * 24) + 18);
                label.Width = 200;
                label.Height = 22;
                label.TextAlign = ContentAlignment.MiddleRight;
                panel.Controls.Add(label);


                if (pi.PropertyType == typeof(string)) // Create a TextBox for string type parameters
                {
                    TextBox text = new TextBox();
                    text.Name = pi.Name;

                    object val = pi.GetValue(proc, null);
                    text.Text = val == null ? "" : val.ToString();
                    
                    text.Height = 22;
                    text.Location = new Point(225, (i * 24) + 18);
                    text.Width = panel.Width - 235;
                    text.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    panel.Controls.Add(text);

                    continue;
                }

                if (pi.PropertyType.BaseType == typeof(Enum)) // Create a ComboBox for enum type parameters.
                {
                    ComboBox combo = new ComboBox();
                    combo.Name = pi.Name;
                    combo.Location = new Point(225, (i * 24) + 18);
                    combo.Width = panel.Width - 235;
                    combo.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    combo.DropDownStyle = ComboBoxStyle.DropDownList;

                    // Iterate over valid enum values to populate the ComboBox
                    foreach (object val in Enum.GetValues(pi.PropertyType))
                        combo.Items.Add(val.ToString());

                    object val2 = pi.GetValue(proc, null);
                    combo.Text = val2 == null ? "" : val2.ToString();

                    panel.Controls.Add(combo);

                    continue;
                }
            }
        }


        /// <summary>
        /// Takes the parameters set by the user in a GroupBox previously configured by ConfigParams and places them
        /// in the given Processor.
        /// </summary>
        /// <param name="panel">The GroupBox containing the parameter values.</param>
        /// <param name="proc">The Processor to load with values entered by the user.</param>
        public static void SaveParams(GroupBox panel, Processor proc)
        {
            PropertyInfo[] pis = proc.GetType().GetProperties(); // Get all public properties in the Processor (parameters)
            
            foreach (PropertyInfo pi in pis)
            {
                if (pi.Name == "ProcessorAttribute") // Skip this, as it's built into the Processor class and is not a parameter
                    continue;


                object[] obj_attrs = pi.GetCustomAttributes(typeof(IgnoreAttribute), false);
                if (obj_attrs.Length == 1)
                    continue;


                // Lookup the control's parameter counterpart by Name.
                Control control = null;
                foreach (Control ctrl in panel.Controls)
                    if (ctrl.Name == pi.Name)
                    {
                        control = ctrl;
                        break;
                    }

                // If we didn't find one, something is wrong.
                if (control == null)
                    throw new ArgumentException("Control not found");


                if (pi.PropertyType == typeof(string)) // For string type parameters, simply use the Text property of the Control
                {
                    pi.SetValue(proc, control.Text, null);

                    continue;
                }
                

                if (pi.PropertyType.BaseType == typeof(Enum)) // For enum type parameters, we must use Enum.Parse on the Text property
                {
                    object val2 = Enum.Parse(pi.PropertyType, control.Text);
                    pi.SetValue(proc, val2, null);

                    continue;
                }
            }
        }
    }


    /// <summary>
    /// Allows a UI name and description to be set for a text processor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ProcessorAttribute : Attribute
    {
        /// <summary>
        /// The friendly name of the text processor to be shown to the user.
        /// </summary>
        public string UiName { get; set; }


        /// <summary>
        /// A description of the text processor to be shown to the user.
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Sets a UI name for the text processor only.
        /// </summary>
        /// <param name="UiName">The display name in the UI of the text processor.</param>
        public ProcessorAttribute(string UiName)
        {
            this.UiName = UiName;
        }


        /// <summary>
        /// Sets a UI name and description for the text processor.
        /// </summary>
        /// <param name="UiName">The name of the text processor as shown in the UI to the user.</param>
        /// <param name="Description">The description of the text processor to be shown in the UI to the user.</param>
        public ProcessorAttribute(string UiName, string Description)
            : this(UiName)
        {
            this.Description = Description;
        }


        /// <summary>
        /// Returns the UiName of this instance.
        /// </summary>
        /// <returns>The UiName of this instance.</returns>
        public override string ToString()
        {
            return UiName;
        }
    }


    public class IgnoreAttribute : Attribute
    {
    }


    /// <summary>
    /// The text processor base class. Inherit from this to make a text processor that handles an entire
    /// query in one string (not broken out line-by-line).
    /// </summary>
    [ProcessorAttribute("Processor")]
    public class Processor
    {
        /// <summary>
        /// The newline (Windows/Unix) to use when splitting or joining lines.
        /// </summary>
        public NewlineConstant NewlineConstant
        {
            get
            {
                if (NewlineStringConstant == "\r\n")
                    return global::ColdPlace.Inquiry.NewlineConstant.Windows;
                else if (NewlineStringConstant == "\n")
                    return global::ColdPlace.Inquiry.NewlineConstant.Unix;
                else
                    throw new ArgumentException("Invalid newline constant.");
            }
            set
            {
                switch (value)
                {
                    case global::ColdPlace.Inquiry.NewlineConstant.Windows:
                        m_NewlineStringConstant = "\r\n";
                        break;

                    case global::ColdPlace.Inquiry.NewlineConstant.Unix:
                        m_NewlineStringConstant = "\n";
                        break;

                    default:
                        throw new ArgumentException("Invalid NewlineConstant.");
                }
            }
        }


        // Private value storage for NewlineStringConstant and NewlineConstant.
        string m_NewlineStringConstant = "\r\n";


        /// <summary>
        /// The string version of the newline constant set by NewlineConstant, used when splitting or joining lines.
        /// </summary>
        [Ignore]
        public string NewlineStringConstant { get { return m_NewlineStringConstant; } }
        


        public Processor()
        {
            NewlineConstant = global::ColdPlace.Inquiry.NewlineConstant.Windows;
        }


        /// <summary>
        /// Retrieves the ProcessorAttribute associated with this Processor derivative.
        /// </summary>
        public ProcessorAttribute ProcessorAttribute
        {
            get
            {
                return Processor.GetProcessorAttribute(this.GetType());
            }
        }


        /// <summary>
        /// Retrieves the ProcessorAttribute associated with the given type.
        /// </summary>
        /// <param name="type">The type of Processor derivative to inspect.</param>
        /// <returns>The associated ProcessorAttribute.</returns>
        public static ProcessorAttribute GetProcessorAttribute(Type type)
        {
            object[] obj_attrs = type.GetCustomAttributes(typeof(ProcessorAttribute), false);

            if (obj_attrs == null || obj_attrs.Length != 1)
                throw new ArgumentException("Processor derivative must contain 1 ProcessorAttribute.");

            return (ProcessorAttribute)obj_attrs[0];
        }


        /// <summary>
        /// Called before Processor.Process in order to validate any parameters set by the user.
        /// </summary>
        /// <returns>Return null on success, an error message on failure.</returns>
        public virtual string ValidateParameters()
        {
            return null;
        }


        /// <summary>
        /// Process the given query text and return the finished result.
        /// </summary>
        /// <param name="input">Query text to be processed.</param>
        /// <returns>The query text after being processed.</returns>
        public virtual string Process(string input)
        {
            return input;
        }
    }


    /// <summary>
    /// Inherit from this to make a text processor that handles a query one line at a time.
    /// </summary>
    [ProcessorAttribute("Line Processor")]
    public class LineProcessor : Processor
    {
    }


    /// <summary>
    /// Indicates a side of a string, used primarily in text processors.
    /// </summary>
    public enum StringSide
    {
        Left,
        Right
    }


    /// <summary>
    /// Inquiry newline constant, used primarily in text processors.
    /// </summary>
    public enum NewlineConstant
    {
        Windows,    // \r\n
        Unix        // \n
    }
}