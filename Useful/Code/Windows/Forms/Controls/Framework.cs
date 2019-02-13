using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Useful.Remoting;
using Useful.Services.Clients;
using Useful.Services;

namespace Useful.Console.Client
{
	/// <summary>
	/// A Windows console client for the framework.
	/// </summary>
	public class Framework
	{
		LoggingClient loggingClient;

		internal void Go()
		{
			System.Console.WriteLine("Press to connect...");
			System.Console.ReadLine();
			loggingClient = new LoggingClient();
			//loggingClient.Initialize();
			loggingClient.MessageArrived += new EventHandler<MessageArrivedEventArgs>(loggingClient_MessageArrived);
			if (loggingClient.ServiceState == ServiceState.Available)
			{
				System.Console.WriteLine("Connected");
				System.Console.ReadLine();
				System.Console.WriteLine("Message: " + loggingClient.LastMessage);
				System.Console.ReadLine();
			}
			else
			{
				System.Console.WriteLine("Failed to connect");
				System.Console.ReadLine();
			}
			return;
		}

		void loggingClient_MessageArrived(object sender, MessageArrivedEventArgs e)
		{
			System.Console.WriteLine("Message from server: " + e.Message);
		}
	}
}
