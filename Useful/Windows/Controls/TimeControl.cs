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
	/// A Windows controls for time.
	/// </summary>
	public partial class TimeControl : Useful.Windows.Forms.Controls.ServiceControl
	{
		TimeClient timeClient;

		// This thread is used to demonstrate both thread-safe and
		// unsafe ways to call a Windows Forms control.
		Thread demoThread;

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		public TimeControl()
		{
			InitializeComponent();

			timeClient = new TimeClient();
			timeClient.TimeArrived += new EventHandler<TimeArrivedEventArgs>(timeClient_TimeArrived);
			timeClient.ServiceStateChanged += new EventHandler<ServiceStateChangedEventArgs>(timeClient_ServiceStateChanged);
		}

		void timeClient_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
		{
			this.demoThread = new Thread(new ThreadStart(this.ThreadProcSafe));

			this.demoThread.Start();
		}

		// This method is executed on the worker thread and makes
		// a thread-safe call on the TextBox control.
		private void ThreadProcSafe()
		{
			this.SetChecked(timeClient.ServiceState == ServiceState.Available);
		}

		void timeClient_TimeArrived(object sender, TimeArrivedEventArgs e)
		{
			MessageBox.Show("Time is: " + e.Time.ToString());
		}
	}
}

