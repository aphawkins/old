//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>The main program containing the program's entry point.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// The main program containing the program's entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        [STAThread]
        private static void Main(string[] args)
        {
            Extensions.CheckNullArgument(() => args);

            Thread.CurrentThread.Name = "MainGUI";

            if (args.Length > 0)
            {
                // Command line given, display console
                NativeMethods.AllocConsole();
                ConsoleMain(args);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Useful.Windows.Forms.CryptographyForm());
            }
        }

        /// <summary>
        /// The main entry point for the console application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        private static void ConsoleMain(string[] args)
        {
            Console.WriteLine(Resource.CommandLine, Environment.CommandLine);

            if (args != null)
            {
                for (int i = 0; i < args.Length; ++i)
                {
                    Console.WriteLine(Resource.ArgumentNameValue, i + 1, args[i]);
                }
            }

            Console.ReadLine();
        }
    }
}