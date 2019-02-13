//-----------------------------------------------------------------------
// <copyright file="Culture.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Methods to aid cultures.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
    using System.Globalization;

    /// <summary>
    /// Methods to aid cultures.
    /// </summary>
    public static class Culture
    {
        /// <summary>
        /// Initialises static members of the <see cref="Culture"/> class.
        /// </summary>
        static Culture()
        {
            Culture.CurrentCulture = CultureInfo.InvariantCulture;
            ////Culture.CaesarCulture = new CultureInfo("it-IT");
        }

        /// <summary>
        /// Gets the culture to use currently.
        /// </summary>
        /// <value>The culture to use currently.</value>
        public static CultureInfo CurrentCulture { get; private set; }

        ///// <summary>
        ///// Gets the culture used for the Caesar shift cipher.
        ///// </summary>
        ///// <value>The culture for the Caesar shift cipher.</value>
        ////public static CultureInfo CaesarCulture { get; private set; }
    }
}
