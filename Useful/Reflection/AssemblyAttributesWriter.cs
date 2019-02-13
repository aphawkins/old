//-----------------------------------------------------------------------
// <copyright file="AssemblyAttributesWriter.cs" company="APH Software">
// Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Reads and contains assembly information for writing to a file.</summary>
//-----------------------------------------------------------------------

namespace Useful.Reflection
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Reads and contains assembly information for writing to a file.
    /// </summary>
    [DebuggerDisplay("Format={Format()}")]
    public static class AssemblyAttributesWriter
    {
        private const string FormatStringCsv = @"{0},{1},{2},{3},{4},{5},{6},{7},{8}";
        private const string FormatStringTxt = @"{0,-60}{1,-15}{2,-15}{3,-10}{4,-12}{5,-23}{6,-15}{7,-30}{8,-20}";

        /// <summary>
        /// The format the output should be.
        /// </summary>
        public enum OutputFormat
        {
            /// <summary>
            /// Formatted text.
            /// </summary>
            Text,

            /// <summary>
            /// Comma Separated Values.
            /// </summary>
            Csv
        }

        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="writer">The stream to write the output to.</param>
        /// <param name="outputFormat">The format the output should be.</param>
        /// <exception cref="ArgumentNullException"> Thrown if <paramref name="writer" /> is null.</exception>
        public static void Write(TextWriter writer, OutputFormat outputFormat)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteLine(GetHeader(outputFormat));

            DirectoryInfo di = new DirectoryInfo(@".");
            foreach (FileInfo fi in di.GetFiles())
            {
                AssemblyAttributes attributes = AssemblyAttributes.ReadAssembly(fi.FullName);
                if (attributes.IsManagedAssembly)
                {
                    writer.WriteLine(Format(attributes, outputFormat));
                }
            }
        }

        private static string Format(AssemblyAttributes attributes, OutputFormat format)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                GetOutputFormat(format),
                attributes.FileName,
                attributes.FileVersion,
                attributes.Version,
                attributes.BuildType,
                attributes.DebugOutput,
                attributes.HasDebuggableAttribute,
                attributes.IsJitOptimized,
                attributes.Company,
                attributes.Copyright);
        }

        private static string GetHeader(OutputFormat format)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                GetOutputFormat(format),
                nameof(AssemblyAttributes.FileName),
                nameof(AssemblyAttributes.FileVersion),
                nameof(AssemblyAttributes.Version),
                nameof(AssemblyAttributes.BuildType),
                nameof(AssemblyAttributes.DebugOutput),
                nameof(AssemblyAttributes.HasDebuggableAttribute),
                nameof(AssemblyAttributes.IsJitOptimized),
                nameof(AssemblyAttributes.Company),
                nameof(AssemblyAttributes.Copyright));
        }

        private static string GetOutputFormat(OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.Csv:
                    return FormatStringCsv;
                case OutputFormat.Text:
                default:
                    return FormatStringTxt;
            }
        }
    }
}