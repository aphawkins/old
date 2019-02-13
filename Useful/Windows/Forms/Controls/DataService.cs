using System;
using System.Messaging;
using System.Threading;
using System.IO;
using System.Globalization;

namespace Useful.Console
{
	class DataService
	{
		private Useful.DataServices.DataService m_ds;
		CultureInfo m_culture = new CultureInfo("en-GB");

		internal DataService()
		{
		}
		
		internal void EmulateExport()
		{
			m_ds = new Useful.DataServices.DataService();
			m_ds.Start();

			// Files
			Thread tFile = new Thread(new ThreadStart(FileThreadProc));
			tFile.Start();

			// Messages
			Thread tQ = new Thread(new ThreadStart(QThreadProc));
			tQ.Start();

			// Web Services
			Thread tWeb = new Thread(new ThreadStart(WebServiceThreadProc));
			tWeb.Start();
		}

		internal void FileThreadProc()
		{
			for (int i = 0 ; i < 1 ; i++)
			{
				Thread.Sleep(2000);
				// File
				StreamWriter sr = new StreamWriter(@"C:\Documents and Settings\Andy\My Documents\Programming\Useful\Useful.DataServices\Import\" + i.ToString(m_culture) + @".xml");
				sr.WriteLine(@"<xml>Hello File " + i.ToString(m_culture) + @"!</xml>");
				sr.Close();
			}
		}

		internal void QThreadProc()
		{
			MessageQueue mq = new MessageQueue (@".\private$\importq");
			mq.Purge();

			Thread.Sleep(20000);

			for (int i = 0 ; i < 20 ; i++)
			{
				Thread.Sleep(1000);
				
				// Message
				// Send a string.
				mq.Send(@"<xml>Hello Message " + i.ToString(m_culture) + @"!</xml>", i.ToString(m_culture));
			}
			mq.Close();
            mq.Dispose();
		}

		internal void WebServiceThreadProc()
		{
			Useful.Console.UsefulDataServicesWebService ws = new Useful.Console.UsefulDataServicesWebService();

			Thread.Sleep(20000);

			for (int i = 0 ; i < 5 ; i++)
			{
				Thread.Sleep(5000);
				
				// Web Service
				// Send a string.
				ws.Export(@"<xml>Hello Web Service " + i.ToString(m_culture) + @"!</xml>");
			}
		}
	}
}
