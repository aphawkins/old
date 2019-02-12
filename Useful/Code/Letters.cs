//-----------------------------------------------------------------------
// <copyright file="Letters.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Character manipulation.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Character manipulation.
    /// </summary>
    internal static class Letters
    {
        /// <summary>
        /// The ISO basic Latin alphabet. <a href="http://en.wikipedia.org/wiki/ISO_basic_Latin_alphabet" />
        /// </summary>
        private static Collection<char> basicLatinAlphabetUppercase;

        /// <summary>
        /// Initializes static members of the <see cref="Letters" /> class.
        /// </summary>
        static Letters()
        {
            Letters.BasicLatinAlphabetUppercase = new Collection<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
        }

        /// <summary>
        /// Gets the letters found in the Latin alphabet.
        /// </summary>
        internal static Collection<char> BasicLatinAlphabetUppercase
        {
            get
            {
                return basicLatinAlphabetUppercase;
            }

            private set
            {
                basicLatinAlphabetUppercase = value;
            }
        }

        /////// <summary>
        /////// Tests to see if a dirty char cleanable.
        /////// </summary>
        /////// <param name="allowedLetters">The letters that the dirty char is allowed to be.</param>
        /////// <param name="dirty">The dirty char that needs cleaning.</param>
        /////// <returns>The clean string.</returns>
        ////internal static bool IsCleanable(Collection<char> allowedLetters, char dirty)
        ////{
        ////    // Check to make sure the letter is in the specified alphabet
        ////    return allowedLetters.Contains(char.ToUpper(dirty, CultureInfo.InvariantCulture));
        ////}

        /////// <summary>
        /////// Cleans a dirty string.
        /////// </summary>
        /////// <param name="allowedLetters">The letters that the dirty char is allowed to be.</param>
        /////// <param name="dirty">The dirty string to clean.</param>
        /////// <returns>The clean string.</returns>
        ////internal static char Clean(Collection<char> allowedLetters, char dirty)
        ////{
        ////    // Check to make sure the letter is in the specified alphabet
        ////    if (allowedLetters.Contains(char.ToUpper(dirty, CultureInfo.InvariantCulture)))
        ////    {
        ////        return char.ToUpper(dirty, CultureInfo.InvariantCulture);
        ////    }
        ////    else
        ////    {
        ////        throw new ArgumentException("Char is uncleanable.");
        ////    }
        ////}
    }
}