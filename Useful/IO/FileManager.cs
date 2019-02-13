//-----------------------------------------------------------------------
// <copyright file="FileManager.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Manages file based IO.</summary>
//-----------------------------------------------------------------------

namespace Useful.IO
{
    using System;
    using System.IO;

    /// <summary>
    /// Class to contain file handling routines.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Checks to ensure the files exists, are writable, etc.
        /// </summary>
        /// <param name="inputFilePath">The file to be read.</param>
        /// <param name="outputFilePath">The file to be written.</param>
        /// <returns>An error code indicating the success.</returns>
        internal static ErrorCode CheckFiles(string inputFilePath, string outputFilePath)
        {
            if (string.IsNullOrEmpty(inputFilePath))
            {
                return ErrorCode.InputFileBlank;
            }

            if (string.IsNullOrEmpty(outputFilePath))
            {
                return ErrorCode.OutputFileBlank;
            }

            if (!File.Exists(inputFilePath))
            {
                return ErrorCode.InputFileNotExists;
            }

            if (string.Equals(Path.GetFullPath(inputFilePath), Path.GetFullPath(outputFilePath), StringComparison.OrdinalIgnoreCase))
            {
                return ErrorCode.InputOutputFileSame;
            }

            if (File.Exists(outputFilePath))
            {
                FileAttributes attribs = File.GetAttributes(outputFilePath);
                if ((attribs & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    return ErrorCode.OutputFileReadOnly;
                }

                File.Delete(outputFilePath);
            }

            ////FileIOPermission io = new FileIOPermission(FileIOPermissionAccess.Write, outputFilePath);
            ////io.Assert();
            ////if (io.AllFiles == FileIOPermissionAccess.NoAccess)
            ////{
            ////    throw new IOException(string.Format("You do not have the security permissions required to write to the path '{0}'.", outputFilePath));
            ////}

            return ErrorCode.None;
        }
    }
}