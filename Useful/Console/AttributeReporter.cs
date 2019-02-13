//-----------------------------------------------------------------------
// <copyright file="AttributeReporter.cs" company="APH Software">
// Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Reports an assembly's attributes.</summary>
//-----------------------------------------------------------------------

namespace Useful.Console
{
    using System.Diagnostics;
    using System.IO;
    using Useful.Reflection;

    /// <summary>
    /// Reports an assembly's attributes.
    /// </summary>
    [DebuggerDisplay("ToString={ToString()}")]
    public static class AttributeReporter
    {
        // Return codes
        private const int Success = 0;
        private const int Failure = -1;

        private static int Main()
        {
            try
            {
                using (TextWriter writer = new StreamWriter(@"AttributeReport.csv", false))
                {
                    AssemblyAttributesWriter.Write(writer, AssemblyAttributesWriter.OutputFormat.Csv);
                }

                return Success;
            }
            catch (IOException ex)
            {
                System.Console.WriteLine(ex.Message);
                return Failure;
            }
        }
    }
}