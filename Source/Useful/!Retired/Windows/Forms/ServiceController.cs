using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Useful.Remoting;
using Useful.Services;

namespace Useful.Windows
{
	/// <summary>
	/// A Windows form for controlling distributed services.
	/// </summary>
	public partial class ServiceController : Form
	{
		DistributedService loggingService;
		//DistributedService timeService;

		/// <summary>
		/// Creates an instance of this class.
		/// </summary>
		public ServiceController()
		{
			InitializeComponent();
			loggingService = new DistributedService(ServiceType.Logging);
			//timeService = new DistributedService(ServiceType.Time);
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			loggingService.Start();
			//timeService.Start();
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			loggingService.Stop();
			//timeService.Start();
		}
	}
}