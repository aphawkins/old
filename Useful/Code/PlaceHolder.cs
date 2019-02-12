//-----------------------------------------------------------------------
// <copyright file="PlaceHolder.cs" company="APH Software">
// Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>The Hello world class. It does not do much. Used for projects that need a class.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
    using System.Diagnostics;

    /// <summary>
    /// The Hello world class. It does not do much. Used for projects that need a class.
    /// </summary>
    [DebuggerDisplay("Hello={HelloWorld()}")]
    public static class Placeholder
    {
        private static string Hello { get; } = HelloWorld();

        private static string HelloWorld()
        {
            return "Hello World!";
        }
    }
}