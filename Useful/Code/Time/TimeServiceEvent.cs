using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Useful.Remoting;

namespace Useful.Services.Clients
{
    /// <summary>
    /// An event raised by the time service.
    /// </summary>
	internal class TimeServiceEvent : RemoteEvent
	{
        /// <summary>
        /// An event for notification that the time has arrived.
        /// </summary>
		public event EventHandler<TimeArrivedEventArgs> TimeArrivedLocally;

        // don't use OneWay here!
        /// <summary>
        /// A time arrived event handler.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The data for the event.</param>
        public void LocallyHandleTimeArrived(object sender, TimeArrivedEventArgs e)
        {
            // forward the message to the client
            TimeArrivedLocally(this, e);
        }
	}
}
