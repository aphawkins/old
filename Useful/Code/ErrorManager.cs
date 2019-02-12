//-----------------------------------------------------------------------
// <copyright file="ErrorManager.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Handles errors.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
    /// <summary>
    /// Contains error handling routines.
    /// </summary>
    internal static class ErrorManager
    {
        /// <summary>
        /// Gets an error message for a given code.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <returns>The error message for a given code.</returns>
        internal static string GetMessage(ErrorCode code)
        {
            switch (code)
            {
                case ErrorCode.Unknown:
                    return "Unknown error.";
                case ErrorCode.None:
                    return "No error.";

                case ErrorCode.InputFileBlank:
                    return "Input file not specified.";

                case ErrorCode.OutputFileBlank:
                    return "Output file not specified.";

                case ErrorCode.InputFileNotExists:
                    return "Input file does not exist.";

                case ErrorCode.InputOutputFileSame:
                    return "Input and Output file are the same.";

                case ErrorCode.OutputFileReadOnly:
                    return "Output file is read-only.";

                case ErrorCode.FileSecurity:
                    return "File security error.";

                default:
                    return "Error getting error message!";
            }
        }
    }
}
