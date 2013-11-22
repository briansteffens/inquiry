/* 
 * This file contains the standard Inquiry text processors as an example for creating custom text processors.
 * 
 * There are two class options to inherit from when making a custom text processor:
 *   - Processor: handles a full query all in one string
 *   - LineProcessor: handles a query one line at a time
 * 
 * To create a custom text processor, inherit from Processor or LineProcessor. Use the ProcessorAttribute 
 * to set the friendly name and description as they will appear to the user. Any public properties of type
 * string or enum will act as a setting for the text processor, being offered to the user for population of the value.
 * You can override ValidateParameters in order to validate these settings before running the text processor.
 * Final text processing occurs within the Process method.
 */

using System;
using System.Text;

namespace ColdPlace.Inquiry.StandardExtensions
{
    [ProcessorAttribute("Trim Whitespace", "Trims whitespace from each line.")]
    public class TrimLineProcessor : LineProcessor
    {
        public override string Process(string input) // This will be called for each line in the query
        {
            return input.Trim(' ', '\t'); // Trim spaces and tabs from each line and return
        }
    }

    [ProcessorAttribute("Line Remove String", "Trims specified string from specified side of each line.")]
    public class RemoveStringLineProcessor : LineProcessor
    {
        // The side of the string (left/right) from which to remove the specified string
        public StringSide RemoveFromSide { get; set; }

        // The string to be removed from the specified side (left/right)
        public string StringToRemove { get; set; }


        public override string ValidateParameters()
        {
            // StringToRemove is required, so return the error message to the Inquiry UI.
            if (string.IsNullOrEmpty(StringToRemove))
                return "StringToRemove must be set";

            return null; // Returning null indicates no validation error
        }


        public override string Process(string input) // This will be called for each line in the query
        {
            string ret = input; // Return variable

            switch (RemoveFromSide)
            {
                case StringSide.Left: // Remove from the left side of the input line
                    if (ret.StartsWith(StringToRemove))
                        ret = ret.Remove(0, StringToRemove.Length);

                    break;

                case StringSide.Right: // Remove from the right side of the input line
                    if (ret.EndsWith(StringToRemove))
                        ret = ret.Remove(ret.Length - StringToRemove.Length, StringToRemove.Length);

                    break;
            }

            return ret;
        }
    }

    [ProcessorAttribute("Greedy Line Remove String", "Trims specified string from specified side of each line. Will remove multiple occurrences of string.")]
    public class GreedyLineRemoveStringProcessor : RemoveStringLineProcessor
    {
        // This class inherits from RemoveStringLineProcessor above and uses its Process method, but looping
        // until all occurrences of the string to remove are gone.
        public override string Process(string input)
        {
            string ret = input;

            switch (RemoveFromSide)
            {
                case StringSide.Left:
                    while (ret.StartsWith(StringToRemove))
                        ret = base.Process(ret);

                    break;

                case StringSide.Right:
                    while (ret.EndsWith(StringToRemove))
                        ret = base.Process(ret);

                    break;
            }

            return ret;
        }
    }

    [ProcessorAttribute("Split", "Splits text by Separator onto multiple lines.")]
    public class SplitProcessor : Processor
    {
        public string Separator { get; set; }

        public override string ValidateParameters()
        {
            if (string.IsNullOrEmpty(NewlineStringConstant))
                return "NewlineConstant must be set.";

            if (string.IsNullOrEmpty(Separator))
                return "JoinSeparator must be set.";

            return null;
        }

        public override string Process(string input)
        {
            // Split input by supplied Separator
            string[] spl = input.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
            
            // Rejoin split result with a newline
            return string.Join(NewlineStringConstant, spl);
        }
    }

    [ProcessorAttribute("Line Append", "Appends specified text to specified side of each line.")]
    public class LineAppendProcessor : LineProcessor
    {
        public string AppendText { get; set; }
        public StringSide AppendToSide { get; set; }

        public override string ValidateParameters()
        {
            if (string.IsNullOrEmpty(NewlineStringConstant))
                return "NewlineConstant must be set.";

            if (string.IsNullOrEmpty(AppendText))
                return "AppendText must be set.";

            return null;
        }

        public override string Process(string input)
        {
            string ret = input;

            switch (AppendToSide)
            {
                case StringSide.Left:
                    ret = AppendText + ret;

                    break;

                case StringSide.Right:
                    ret = ret + AppendText;

                    break;
            }

            return ret;
        }

        public LineAppendProcessor()
        {
            NewlineConstant = global::ColdPlace.Inquiry.NewlineConstant.Windows;
        }
    }

    [ProcessorAttribute("Line Join", "Combines all lines into one, joined by JoinSeparator.")]
    public class LineJoinProcessor : Processor
    {
        public string JoinSeparator { get; set; }

        public override string ValidateParameters()
        {
            if (string.IsNullOrEmpty(NewlineStringConstant))
                return "NewlineConstant must be set.";

            if (string.IsNullOrEmpty(JoinSeparator))
                return "JoinSeparator must be set.";

            return null;
        }

        public override string Process(string input)
        {
            // Split input by newline
            string[] lines = input.Split(new string[] { NewlineStringConstant }, StringSplitOptions.None);

            // Rejoin split result on supplied JoinSeparator
            return string.Join(JoinSeparator, lines);
        }
    }

    [ProcessorAttribute("Remove Empty Lines", "Removes empty lines.")]
    public class RemoveEmptyLinesProcessor : Processor
    {
        public override string ValidateParameters()
        {
            if (string.IsNullOrEmpty(NewlineStringConstant))
                return "NewlineConstant must be set.";

            return null;
        }

        public override string Process(string input)
        {
            string[] lines = input.Split(new string[] { NewlineStringConstant }, StringSplitOptions.None);

            StringBuilder sb = new StringBuilder();
            bool first = true;

            // The only reason we loop over lines ourselves instead of having string.Split do the removal of empty lines
            // is to get rid of lines that contain only whitespace. string.Split can only remove empty strings.
            foreach (string line in lines)
            {
                if (line.Trim() == "") continue;

                if (!first) 
                    sb.Append(NewlineStringConstant);

                first = false;

                sb.Append(line);
            }

            return sb.ToString();
        }
    }
}