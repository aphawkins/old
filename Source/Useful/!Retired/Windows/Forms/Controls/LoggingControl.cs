using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Useful.Services.Clients;
using Useful.Services;

namespace Useful.Windows.Forms.Controls
{
	/// <summary>
	/// A Windows control for logging.
	/// </summary>
	public partial class LoggingControl : Useful.Windows.Forms.Controls.ServiceControl
	{
		LoggingClient loggingClient;
        //string message;

		// This thread is used to demonstrate both thread-safe and
		// unsafe ways to call a Windows Forms control.
		Thread serviceStateThread;

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		public LoggingControl()
		{
			InitializeComponent();

			loggingClient = new LoggingClient();
			loggingClient.MessageArrived += new EventHandler<MessageArrivedEventArgs>(loggingClient_MessageArrived);
			loggingClient.ServiceStateChanged += new EventHandler<ServiceStateChangedEventArgs>(loggingClient_ServiceStateChanged);
		}

		void loggingClient_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
		{
			this.serviceStateThread = new Thread(new ThreadStart(this.ThreadProcSafe));
			this.serviceStateThread.Start();
		}

		// This method is executed on the worker thread and makes
		// a thread-safe call on the TextBox control.
		private void ThreadProcSafe()
		{
			this.SetChecked(loggingClient.ServiceState == ServiceState.Available);
		}

		void loggingClient_MessageArrived(object sender, MessageArrivedEventArgs e)
		{
            MessageBox.Show(Resource.Exclamation + " " + e.Message, Resource.Exclamation, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				loggingClient.BroadcastMessage(Resource.Hello);
			}
			catch (ServiceNotAvailableException)
			{
				base.SetChecked(loggingClient.ServiceState == ServiceState.Available);
			}
		}
	}
}

