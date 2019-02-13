// -----------------------------------------------------------------------
// <copyright file="Settings.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace BookMan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Settings
    {
        public static string DatabasePath { get; set; }
        public static string DatabasePassword { get; set; }
        public static Version DatabaseVersion { get; set; }
    }
}
