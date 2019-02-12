//-----------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Native Interop Methods.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Native Interop Methods.
    /// </summary>
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool AllocConsole();
    }
}
