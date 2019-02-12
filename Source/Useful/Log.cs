// -----------------------------------------------------------------------
// <copyright file="Log.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace BookMan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    public static class Log
    {
        private const string ExceptionCategory = "Exception";
        private const string ErrorCategory = "Error";
        private const string InfoCategory = "Info";

        public static void LogException(Exception ex)
        {
            Contract.Requires(ex != null);

            Debug.WriteLine("Exception! " + ex.ToString(), ExceptionCategory);
        }

        public static void LogError(string message, params object[] args)
        {
            Debug.WriteLine(string.Format(CultureInfo.InvariantCulture, message, args), ErrorCategory);
        }

        public static void LogInfo(string message, params object[] args)
        {
            Debug.WriteLine(string.Format(CultureInfo.InvariantCulture, message, args), InfoCategory);
        }
    }
}
