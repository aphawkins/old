using System;
using System.Messaging;
using System.Threading;
using System.IO;

namespace Useful.DataServices.Console
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		private static Useful.DataServices.DataService m_ds = null;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			EmulateExport emm = new EmulateExport();

			m_ds = new Useful.DataServices.DataService();
			m_ds.Start();

			System.Console.ReadLine();
		}
	}

	class EmulateExport
	{
		internal EmulateExport()
		{
//			// Files
//			Thread tFile = new Thread(new ThreadStart(FileThreadProc));
//			tFile.Start();
//
//			// Messages
//			Thread tQ = new Thread(new ThreadStart(QThreadProc));
//			tQ.Start();
//
//			// Web Services
//			Thread tWeb = new Thread(new ThreadStart(WebServiceThreadProc));
//			tWeb.Start();
		}

		internal void FileThreadProc()
		{
			for (int i = 0 ; i < 10 ; i++)
			{
				Thread.Sleep(2000);
				// File
				StreamWriter sr = new StreamWriter(@"C:\Inetpub\wwwroot\Enterprise\DataServices\Export\111\" + i.ToString() + @".xml");
				sr.WriteLine(@"<xml>Hello File " + i.ToString() + @"!</xml>");
				sr.Close();
			}
		}

		internal void QThreadProc()
		{
			MessageQueue mq = new MessageQueue (@".\private$\exportq");
			mq.Purge();

			Thread.Sleep(20000);

			for (int i = 0 ; i < 20 ; i++)
			{
				Thread.Sleep(1000);
				
				// Message
				// Send a string.
				mq.Send(@"<xml>Hello Message " + i.ToString() + @"!</xml>", i.ToString());
			}
		}

		internal void WebServiceThreadProc()
		{
			Useful.DataServices.Console.DataService.UsefulDataServicesWebService ws = new Useful.DataServices.Console.DataService.UsefulDataServicesWebService();

			Thread.Sleep(20000);

			for (int i = 0 ; i < 5 ; i++)
			{
				Thread.Sleep(5000);
				
				// Web Service
				// Send a string.
				ws.Export(@"<xml>Hello Web Service " + i.ToString() + @"!</xml>");
			}
		}
	}
}
