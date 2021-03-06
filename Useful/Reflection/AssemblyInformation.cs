﻿//-----------------------------------------------------------------------
// <copyright file="AssemblyInformation.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>This class uses the System.Reflection.Assembly class to access assembly meta-data.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
	using System;
	using System.Diagnostics.Contracts;
	using System.Reflection;
	using System.Runtime.InteropServices;

    /// <summary>
    /// Accesses information from Assembly Attributes.
    /// </summary>
    public static class AssemblyInformation
    {
        /// <summary>
        /// Gets the executing assembly.
        /// </summary>
        /// <returns>The current calling assembly.</returns>
        public static Assembly This()
        {
			Contract.Ensures(Contract.Result<Assembly>() != null);

            return Assembly.GetCallingAssembly();
        }

        /// <summary>
        /// Gets the assembly's name.
        /// </summary>
        /// <returns>Gets the assembly's name.</returns>
        public static string AssemblyName()
        {
            return Assembly.GetCallingAssembly().GetName().Name;
        }

        /// <summary>
        /// Gets the full name of the assembly, also known as the display name.
        /// </summary>
        /// <value>The assembly's fully qualified name.</value>
        public static string AssemblyFullyQualifiedName()
        {
			Contract.Ensures(Contract.Result<string>() != null);

            return Assembly.GetCallingAssembly().GetName().FullName;
        }

        /// <summary>
        /// Gets the location of the assembly as specified originally, for example, in an System.Reflection.AssemblyName object.
        /// </summary>
        /// <value>The assembly's code base.</value>
        public static string CodeBase()
        {
			Contract.Ensures(Contract.Result<string>() != null);

            return new Uri(Assembly.GetCallingAssembly().CodeBase).LocalPath;
        }

        /// <summary>
        /// Gets the path or UNC location of the loaded file that contains the manifest.
        /// </summary>
        /// <value>The assembly's location.</value>
        public static string Location()
        {
			Contract.Ensures(Contract.Result<string>() != null);

            return Assembly.GetCallingAssembly().Location;
        }

        /// <summary>
        /// Gets the major, minor, revision, and build numbers of the assembly. 
        /// </summary>
        /// <value>The assembly's version.</value>
        public static Version Version()
        {
            return Assembly.GetCallingAssembly().GetName().Version;
        }

        /// <summary>
        /// Get the copyright information.
        /// </summary>
        /// <returns>The copyright information.</returns>
        public static string Copyright()
        {
            AssemblyCopyrightAttribute attribute = GetCustomAttribute<AssemblyCopyrightAttribute>();
            return attribute == null ? string.Empty : attribute.Copyright;
        }

        /// <summary>
        /// Get the company information.
        /// </summary>
        /// <returns>The company information.</returns>
        public static string Company()
        {
            AssemblyCompanyAttribute attribute = GetCustomAttribute<AssemblyCompanyAttribute>();
            return attribute == null ? string.Empty : attribute.Company;
        }

        /// <summary>
        /// Get the description information.
        /// </summary>
        /// <returns>The description information.</returns>
        public static string Description()
        {
            AssemblyDescriptionAttribute attribute = GetCustomAttribute<AssemblyDescriptionAttribute>();
            return attribute == null ? string.Empty : attribute.Description;
        }

        /// <summary>
        /// Get the product name custom attribute for an assembly manifest.
        /// </summary>
        /// <returns>Gets the assembly's product.</returns>
        public static string Product()
        {
            AssemblyProductAttribute attribute = GetCustomAttribute<AssemblyProductAttribute>();
            return attribute == null ? string.Empty : attribute.Product;
        }

        /// <summary>
        /// Gets the assembly title custom attribute for an assembly manifest.
        /// </summary>
        /// <returns>The assembly's version.</returns>
        public static string Title()
        {
            AssemblyTitleAttribute attribute = GetCustomAttribute<AssemblyTitleAttribute>();
            return attribute == null ? string.Empty : attribute.Title;
        }

        public static Guid Guid()
        {
            GuidAttribute attribute = GetCustomAttribute<GuidAttribute>();
            Guid result;
            if (attribute == null || !System.Guid.TryParse(attribute.Value, out result))
            {
                return new Guid();
            }

            return result;
        }

        private static T GetCustomAttribute<T>() where T : Attribute
        {
            object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(T), false);
            if (attributes.Length == 0)
            {
                return null;
            }

            return (T)attributes[0];
        }
    }
}
