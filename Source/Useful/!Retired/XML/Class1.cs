using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			XmlValidation validator = new XmlValidation();
			validator.ValidateFiles("*.xhtml", XmlValidationType.Xhtml11);
			List<string> ss = validator.Messages;
			foreach (string s in ss)
			{
				Console.WriteLine(s);
			}
			Console.ReadLine();
		}
	}
}
