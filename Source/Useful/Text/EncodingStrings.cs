//-----------------------------------------------------------------------
// <copyright file="EncodingStrings.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Retrieves encoding strings.</summary>
//-----------------------------------------------------------------------

namespace Useful.Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal static class EncodingStrings
    {
        static EncodingStrings()
        {
            Encodings = new Dictionary<string, Encoding>();
            Encodings.Add("Match input", null);
            Encodings.Add("UTF-8", new UTF8Encoding(true));
            Encodings.Add("Unicode little endian (Windows, OS X)", new UnicodeEncoding(false, true));
            Encodings.Add("Unicode big endian (Linux)", new UnicodeEncoding(true, true));
        }

        internal static Dictionary<string, Encoding> Encodings { get; private set; }
    }
}
