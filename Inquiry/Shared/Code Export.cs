/* ColdPlace.Inquiry - code export shared classes
 * 
 * This file contains classes and attributes necessary for impelementing custom Inquiry code exporters.
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
    /// Marks a property in a class that inherits from CodeExportParams as a needed value for the CodeExporter to run. A property marked with this
    /// attribute will be filled by the end-user under 'Language settings' in the dialog for Options->'Code Export Settings'.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CodeExportFieldAttribute : Attribute
    {
        /// <summary>
        /// The friendly name to display in the Inquiry UI when asking the end-user to fill this setting.
        /// </summary>
        public string UiName { get; set; }

        /// <summary>
        /// Marks a property in a class that inherits from CodeExportParams as a needed value for the CodeExporter to run. A property marked with this
        /// attribute will be filled by the end-user under 'Language settings' in the dialog for Options->'Code Export Settings'.
        /// </summary>
        /// <param name="uiName">The friendly name to display in the Inquiry UI when asking the end-user to fill this setting.</param>
        public CodeExportFieldAttribute(string uiName)
        {
            UiName = uiName;
        }
    }

    /// <summary>
    /// Inherit from this class and add properties marked with the attribute CodeExportFieldAttribute to feed settings into your CodeExporter.
    /// </summary>
    public class CodeExportParams
    {
    }


    /// <summary>
    /// Marks a class that inherits from CodeExporter as an Inquiry code exporter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CodeExporterAttribute : Attribute
    {
        /// <summary>
        /// The name of the language your code exporter will output code for.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Marks a class that inherits from CodeExporter as an Inquiry code exporter.
        /// </summary>
        /// <param name="language">The name of the language your code exporter will output code for.</param>
        public CodeExporterAttribute(string language)
        {
            Language = language;
        }
    }

    /// <summary>
    /// Inherit from this to create a custom CodeExporter.
    /// </summary>
    public abstract class CodeExporter
    {
        /// <summary>
        /// Gets an object ready to be filled with parameters entered by the end-user. Override this function to return your language-specific required settings.
        /// </summary>
        /// <returns>An instance of CodeExportParams or derivative ready to be filled with parameters entered by the end-user.</returns>
        public abstract CodeExportParams CreateParams();

        /// <summary>
        /// Performs a code export.
        /// </summary>
        /// <param name="project">The Inquiry project containing the queries to be exported.</param>
        /// <param name="parameters">The parameters entered by the end-user for the code export.</param>
        /// <returns>The exported language code.</returns>
        public abstract string Export(QueryProject project, CodeExportParams parameters);

        /// <summary>
        /// Convenience function that attempts to return the CodeExporterAttribute associated with this CodeExporter derivative.
        /// </summary>
        public CodeExporterAttribute CodeExporterAttribute
        {
            get
            {
                object[] obj_attrs = GetType().GetCustomAttributes(typeof(CodeExporterAttribute), false);

                if (obj_attrs == null || obj_attrs.Length != 1)
                    throw new ArgumentException("CodeExporter derivative must contains 1 CodeExporter.");

                return (CodeExporterAttribute)obj_attrs[0];
            }
        }

        /// <summary>
        /// Returns the language this CodeExporter renders.
        /// </summary>
        /// <returns>Returns the language this CodeExporter renders.</returns>
        public override string ToString()
        {
            return CodeExporterAttribute.Language;
        }
    }
}