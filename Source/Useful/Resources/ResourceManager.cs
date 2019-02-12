//-----------------------------------------------------------------------
// <copyright file="ResourceManager.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Used for accessing internal resources.</summary>
//-----------------------------------------------------------------------

namespace Useful.Resources
{
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    internal static class ResourceManager
    {
        private static readonly string basePath = AssemblyInformation.AssemblyName;
        
        internal static Stream LoadAboutFile()
        {
            return LoadResource(basePath + @".Resources.About.rtf");
        }

        private static Stream LoadResource(string fileName)
        {
            Stream embeddedStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);

            if (embeddedStream == null)
            {
                throw new IOException(string.Format(CultureInfo.CurrentCulture, "Could not find the resource file '{0}'.", fileName));
            }

            return embeddedStream;
        }
    }
}
