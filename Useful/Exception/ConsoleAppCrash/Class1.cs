namespace ConsoleAppCrash
{
	using System;

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
			Console.WriteLine("By default .NET 1.1 applications will show a Continue/Debug messagebox when a unhandled exception is thrown.");
			Console.WriteLine("This registry key controls the behaviour:");
			Console.WriteLine(@"HKEY_LOCAL_MACHINE\Software\Microsoft\.NETFramework\DbgJITDebugLaunchSetting");
			Console.WriteLine("It should be changed so that no messagebox is shown.");
			Console.WriteLine("See here:");
			Console.WriteLine(@"http://msdn.microsoft.com/en-us/library/2ac5yxx6(VS.71).aspx");
			Console.WriteLine("ProcDump should be configured to capture a dump:");
			Console.WriteLine("procdump -t {appname}.exe");
			Console.WriteLine();
			Console.WriteLine("Press any key to crash!");
			Console.Read();
			throw new Exception("Unhandled exception thrown!");
		}
	}
}
