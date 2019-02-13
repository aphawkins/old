//-----------------------------------------------------------------------
// <copyright file="AssemblyAttributes.cs" company="APH Software">
// Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Reads and contains assembly information for writing to a file.</summary>
//-----------------------------------------------------------------------

namespace Useful.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using static System.Diagnostics.DebuggableAttribute;

    /// <summary>
    /// Reads and contains assembly information for writing to a file.
    /// </summary>
    [DebuggerDisplay("Format={Format()}")]
    public sealed class AssemblyAttributes
    {
        private const string FormatStringTxt = @"{0,-60}{1,-15}{2,-15}{3,-10}{4,-12}{5,-23}{6,-15}{7,-30}{8,-20}";
        private const string FormatStringCsv = @"{0},{1},{2}{3},{4},{5},{6},{7},{8}";

        /// <summary>
        /// Gets the build type e.g. Debug|Release.
        /// </summary>
        public string BuildType { get; private set; }

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public string Company { get; private set; }

        /// <summary>
        /// Gets the copyright.
        /// </summary>
        public string Copyright { get; private set; }

        /// <summary>
        /// Gets the debug information [None|Full|pdb-only].
        /// </summary>
        public string DebugOutput { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the assembly's filename.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the assembly's file version.
        /// </summary>
        public Version FileVersion { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the debuggable attribute property.
        /// </summary>
        public bool HasDebuggableAttribute { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the assembly JIT optimized.
        /// </summary>
        public bool IsJitOptimized { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this is a managed assembly.
        /// </summary>
        public bool IsManagedAssembly { get; private set; }

        /// <summary>
        /// Gets the assembly's version.
        /// </summary>
        public Version Version { get; private set; }

        /// <summary>
        /// Analyzes an assembly to read its attributes.
        /// </summary>
        /// <param name="assemblyFile">Path to the assembly.</param>
        /// <returns>Attributes from the assembly.</returns>
        public static AssemblyAttributes ReadAssembly(string assemblyFile)
        {
            AssemblyAttributes attribs = new AssemblyAttributes();
            attribs.FileName = new FileInfo(assemblyFile).Name;

            Assembly reflectedAssembly;

            try
            {
                reflectedAssembly = Assembly.ReflectionOnlyLoadFrom(assemblyFile);
            }
            catch (BadImageFormatException)
            {
                // Not a valid asssembly
                attribs.IsManagedAssembly = false;
                return attribs;
            }
            catch (FileLoadException)
            {
                // Not a .Net managed assembly
                attribs.IsManagedAssembly = false;
                return attribs;
            }

            attribs.IsManagedAssembly = true;

            // If the 'DebuggableAttribute' is not found then it is definitely an OPTIMIZED build
            attribs.BuildType = "Release";
            attribs.DebugOutput = "Full";

            attribs.Version = reflectedAssembly.GetName().Version;

            IList<CustomAttributeData> list = CustomAttributeData.GetCustomAttributes(reflectedAssembly);
            foreach (CustomAttributeData data in list)
            {
                if (data.AttributeType == typeof(DebuggableAttribute))
                {
                    attribs.HasDebuggableAttribute = true;

                    // Just because the 'DebuggableAttribute' is found doesn't necessarily mean
                    // it's a DEBUG build; we have to check the JIT Optimization flag
                    // i.e. it could have the "generate PDB" checked but have JIT Optimization enabled
                    DebuggingModes modes = (DebuggingModes)data.ConstructorArguments[0].Value;
                    attribs.IsJitOptimized = (modes & DebuggingModes.DisableOptimizations) != DebuggingModes.DisableOptimizations;
                    attribs.BuildType = attribs.IsJitOptimized ? "Release" : "Debug";

                    // check for Debug Output "full" or "pdb-only"
                    attribs.DebugOutput = (modes & DebuggingModes.Default) != DebuggingModes.None ? "Full" : "pdb-only";

                    continue;
                }
                else if (data.AttributeType == typeof(AssemblyFileVersionAttribute))
                {
                    Version ver;
                    if (Version.TryParse((string)data.ConstructorArguments[0].Value, out ver))
                    {
                        attribs.FileVersion = ver;
                    }
                }
                else if (data.AttributeType == typeof(AssemblyCompanyAttribute))
                {
                    attribs.Company = (string)data.ConstructorArguments[0].Value;
                }
                else if (data.AttributeType == typeof(AssemblyCopyrightAttribute))
                {
                    attribs.Copyright = (string)data.ConstructorArguments[0].Value;
                }
            }

            ////object[] customAttribs = reflectedAssembly.GetCustomAttributes(typeof(DebuggableAttribute), false);

            ////// If the 'DebuggableAttribute' is not found then it is definitely an OPTIMIZED build
            ////if (customAttribs.Length > 0)
            ////{
            ////    // Just because the 'DebuggableAttribute' is found doesn't necessarily mean
            ////    // it's a DEBUG build; we have to check the JIT Optimization flag
            ////    // i.e. it could have the "generate PDB" checked but have JIT Optimization enabled
            ////    DebuggableAttribute debuggableAttribute = customAttribs[0] as DebuggableAttribute;
            ////    if (debuggableAttribute != null)
            ////    {
            ////        attribs.HasDebuggableAttribute = true;
            ////        attribs.IsJitOptimized = !debuggableAttribute.IsJITOptimizerDisabled;
            ////        attribs.BuildType = attribs.IsJitOptimized ? "Release" : "Debug";

            ////        // check for Debug Output "full" or "pdb-only"
            ////        attribs.DebugOutput = (debuggableAttribute.DebuggingFlags & DebuggableAttribute.DebuggingModes.Default) != DebuggableAttribute.DebuggingModes.None ? "Full" : "pdb-only";
            ////    }
            ////}
            ////else
            ////{
            ////    attribs.BuildType = "Release";
            ////    attribs.DebugOutput = "Full";
            ////}

            ////customAttribs = reflectedAssembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            ////if (customAttribs.Length > 0)
            ////{
            ////    attribs.FileVersion = Version.Parse((customAttribs[0] as AssemblyFileVersionAttribute).Version);
            ////}

            ////attribs.Version = reflectedAssembly.GetName().Version;

            ////customAttribs = reflectedAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            ////if (customAttribs.Length > 0)
            ////{
            ////    attribs.Company = (customAttribs[0] as AssemblyCompanyAttribute).Company;
            ////}

            ////customAttribs = reflectedAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            ////if (customAttribs.Length > 0)
            ////{
            ////    attribs.Copyright = (customAttribs[0] as AssemblyCopyrightAttribute).Copyright;
            ////}

            return attribs;
        }
    }
}