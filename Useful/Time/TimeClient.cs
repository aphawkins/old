using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net.Sockets;

using Useful.Remoting;

namespace Useful.Services.Clients
{
    /// <summary>
    /// A base class for a time client.
    /// </summary>
	public sealed class TimeClient : RemoteClient, ITimeService
	{
		/// <summary>
		/// This event is raised when a new time arrives.
		/// </summary>
		public event EventHandler<TimeArrivedEventArgs> TimeArrived;

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public TimeClient() : base(ServiceType.Time)
		{
            base.ServerPort = 9001;
            base.ClientPort = 0;
            base.HostName = "192.168.1.64";
            base.UseSecurity = false;
            base.RemoteType = typeof(ITimeService);

			Initialize();
		}

        /// <summary>
        /// Gets the time.
        /// </summary>
        public DateTime LatestTime
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// Handles a Time Arrived event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The data for the event.</param>
		private void OnTimeArrived(object sender, TimeArrivedEventArgs e)
		{
            //Log("Received: {0}", msg);
        
			if (TimeArrived != null)
			{
				TimeArrived(sender, e);
			}
		}

        /// <summary>
        /// Connects to the remote service.
        /// </summary>
        private new void Initialize()
        {
			try
			{
				base.Initialize();

				//Log("Press to listen...");

				// this one will be created in the client's context and a 
				// reference will be passed to the server
				TimeServiceEvent eventWrapper = new TimeServiceEvent();

				// register the local handler with the "remote" handler
				eventWrapper.TimeArrivedLocally += new EventHandler<TimeArrivedEventArgs>(OnTimeArrived);

				//Log("Registering event at server");
				((ITimeService)RemoteObject).TimeArrived += new EventHandler<TimeArrivedEventArgs>(eventWrapper.LocallyHandleTimeArrived);

				//Log("Event registered. Waiting for messages.");
			}
			catch (SocketException ex)
			{
				// Log.Writeline("Connection to Logging service failed. " + ex.ToString())
				System.Diagnostics.Debug.WriteLine(ex.ToString());

				base.ServiceState = ServiceState.Unavailable;
			}
        }

		/// <summary>
		/// Disconnects from the remote time service.
		/// </summary>
		public override void Disconnect()
		{
			base.Disconnect();
		}


		/// <summary>
		/// Broadcasts the time.
		/// </summary>
		/// <param name="time">The time to broadcast.</param>
		public void BroadcastTime(DateTime time)
		{
			base.CheckConnection();

			((ITimeService)RemoteObject).BroadcastTime(time);
		}
	}
}
