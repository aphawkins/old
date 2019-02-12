//-----------------------------------------------------------------------
// <copyright file="ErrorCode.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Error codes.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
    /// <summary>
    /// Error codes used internally.
    /// </summary>
    internal enum ErrorCode
    {
        /// <summary>
        /// An error without a specific code.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// No error.
        /// </summary>
        None = 0,

        // General errors >= 100
        // File errors >= 100

        /// <summary>
        /// Input file is blank.
        /// </summary>
        InputFileBlank = 100,

        /// <summary>
        /// Output file is blank.
        /// </summary>
        OutputFileBlank = 101,

        /// <summary>
        /// Input file does not exist.
        /// </summary>
        InputFileNotExists = 102,

        /// <summary>
        /// Input and output files have the same name.
        /// </summary>
        InputOutputFileSame = 103,

        /// <summary>
        /// The output file is read-only.
        /// </summary>
        OutputFileReadOnly = 104,

        /// <summary>
        /// The file does not have the correct security permissions.
        /// </summary>
        FileSecurity = 105,

        // Cipher errors >= 200
    }
}