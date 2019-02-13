using System;
using System.Collections.Generic;
using System.Text;

using Useful.Console;
using Useful.Xml;

namespace Useful.Console
{
	class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			switch (args[0])
			{
				case ("1"):
					{
						Useful.Console.Challenges.sailorsAndAMonkey(5, 1);
						break;
					}
				case ("2"):
					{
						Useful.Console.Challenges.queens(15);
						break;
					}
				case ("3"):
					{
						Useful.Console.Challenges.squares();
						break;
					}
				case ("4"):
					{
						Useful.Console.Challenges.suDoku();
						break;
					}
				case ("5"):
					{
						Useful.Console.DataService ds = new Useful.Console.DataService();
						ds.EmulateExport();
						break;
					}
				case ("6"):
					{
						XmlValidation validator = new XmlValidation();
						validator.ValidateFiles("*.html", XmlValidationType.Xhtml11);
						List<string> ss = validator.Messages;
						foreach (string s in ss)
						{
							System.Console.WriteLine(s);
						}
						break;
					}
			}

			//System.Console.ReadLine();
			//System.Console.WriteLine("Testing server: " + rem.Test().ToString());
			System.Console.ReadLine();
		}
	}
}
