/* 
 * This file contains the C# code exporter and parameter class as an example for custom code exporters.
 * 
 * The process of creating a custom code exporter is simpler than this file may appear - generating C#
 * code within C# itself isn't exactly pretty. 
 * 
 * Simply inherit from CodeExporter and mark it with the CodeExporterAttribute. Use this attribute to set the
 * friendly name of the language your code exporter is for. Override CodeExporter.Export and use 'project'
 * to generate code. Finally, return the generated code.
 * 
 * If your exporter requires special settings to be set by the end-user, inherit from CodeExportParams.
 * Create a public string property with get and set accessors for each setting you need, and mark them
 * with the CodeExportFieldAttribute, which allows you to set friendly UI names for your parameters.
 * Finally, override CodeExporter.CreateParams in your inherited CodeExporter class and return a new 
 * instance of your CodeExportParams derivative.
 */

using System;
using System.Text;

namespace ColdPlace.Inquiry.StandardExtensions
{
    /// <summary>
    /// This defines the parameters required by the C# code exporter to run. The Inquiry UI will use this class to display
    /// the necessary settings, retrieve the values from the end-user, and provide them to CsCodeExporter.
    /// </summary>
    public class CsCodeExportParams : CodeExportParams
    {
        // The C# namespace into which the generated code should be placed.
        [CodeExportField("Namespace")]
        public string Namespace { get; set; }

        // The name of the class that will contain an individual query and its connection name.
        [CodeExportField("Query class")]
        public string QueryClass { get; set; }

        // The name of the class that will provide access to all queries in the export.
        [CodeExportField("Query collection class")]
        public string QueryCollectionClass { get; set; }
    }


    /// <summary>
    /// This class performs the C# code generation.
    /// </summary>
    [CodeExporter("C#")]
    public class CsCodeExporter : CodeExporter
    {
        // We override CreateParams in order to return an instance of the custom C# parameter class. The Inquiry UI will use this
        // to provide CsCodeExporter with necessary settings supplied by the end-user.
        public override CodeExportParams CreateParams()
        {
            return new CsCodeExportParams();
        }


        // Export accepts a QueryProject containing all of the queries to be exported and a CodeExportParams with parameters set by the user.
        public override string Export(QueryProject project, CodeExportParams parameters)
        {
            // Test that the supplied parameters instance is compatible with the C# parameters object before we upcast.
            if (!(parameters is CsCodeExportParams))
                throw new ArgumentException("Parameters must be able to be upcasted to CsCodeExportParams.");

            // Upcast the parameters object so we can access the C#-specific settings.
            CsCodeExportParams Params = (CsCodeExportParams)parameters;
            

            // Here we begin to generate the exported code file..
            StringBuilder sb = new StringBuilder(); // Using a StringBuilder for performance over normal string concatenation

            sb.AppendFormat ("namespace {0}\r\n", Params.Namespace); // Namespace definition using a namespace supplied by the user.
            sb.Append       ("{\r\n");

            // Here we generate the query class, which stores a single SQL query and its associated connection name.
            sb.AppendFormat ("\tpublic class {0}\r\n", Params.QueryClass);
            sb.Append       ("\t{\r\n");
            sb.Append       ("\t\tpublic string Query { get; set; }\r\n");
            sb.Append       ("\t\tpublic string ConnectionName { get; set; }\r\n");
            sb.AppendFormat ("\r\n");
            sb.AppendFormat ("\t\tpublic static implicit operator string({0} query)\r\n", Params.QueryClass);
            sb.Append       ("\t\t{\r\n");
            sb.AppendFormat ("\t\t\treturn query.Query;\r\n");
            sb.Append       ("\t\t}\r\n");
            sb.AppendFormat ("\r\n");
            sb.AppendFormat ("\t\tpublic {0}(string query, string connectionName)\r\n", Params.QueryClass);
            sb.Append       ("\t\t{\r\n");
            sb.AppendFormat ("\t\t\tQuery = query;\r\n");
            sb.AppendFormat ("\t\t\tConnectionName = connectionName;\r\n");
            sb.Append       ("\t\t}\r\n");
            sb.Append       ("\t}\r\n");
            sb.AppendFormat ("\r\n");


            // Here we create the query collection class. This exposes all project queries to the target language.
            sb.AppendFormat ("\tpublic static class {0}\r\n", Params.QueryCollectionClass);
            sb.Append       ("\t{\r\n");

            // Iterate over all folders and queries in the project recursively, exporting each in turn.
            foreach (QueryNode node in project.Root.Children) 
                recursiveExport(sb, node, 2, Params);

            sb.Append       ("\t}\r\n");

            sb.Append       ("}");


            // Return the completed code generation to the Inquiry UI to display or write to file
            return sb.ToString();
        }


        // This function iterates over the contents of an Inquiry project recursively, appending exported code to the StringBuilder.
        // 'level' refers to the level of recursion, which can be used for proper indentation.
        void recursiveExport(StringBuilder sb, QueryNode node, int level, CsCodeExportParams Params)
        {
            // This will store the base level of indentation: one tab per level.
            string tabs = ""; 
            for (int i = 0; i < level; i++)
                tabs += "\t";

            if (node is Folder) // If the current node is a folder, create a static class representing it and recall this function
            {
                Folder f = (Folder)node;

                // Convert spaces in the folder name to underscores and write the name of the folder's corresponding static class
                sb.AppendFormat("\r\n{0}public static class {1}\r\n", tabs, f.Name.Replace(" ", "_"));
                sb.Append(tabs + "{\r\n");

                // Iterate over all child nodes in this folder and recall this recursive function for each of them
                foreach (QueryNode node2 in f.Children)
                    recursiveExport(sb, node2, level + 1, Params);

                sb.Append(tabs + "}\r\n\r\n");
            }
            else if (node is Query) // If the current node is a query, write its corresponding get property, returning a new query class containing it
            {
                Query q = (Query)node;

                sb.Append(tabs + "public static " + Params.QueryClass + " " + q.Name.Replace(" ", "_") + " { get { return new " + Params.QueryClass + "(\"" + q.QueryText.Replace("\r\n", " ") + "\", \"" + q.DatabaseName + "\"); } }\r\n");
            }
        }
    }
}
