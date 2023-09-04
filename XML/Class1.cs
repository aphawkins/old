namespace XML
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    internal class Class1
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            XmlValidation validator = new();
            validator.ValidateFiles("*.xhtml", XmlValidationType.Xhtml11);
            List<string> ss = validator.Messages;
            foreach (string s in ss)
            {
                Console.WriteLine(s);
            }
            _ = Console.ReadLine();
        }
    }
}
