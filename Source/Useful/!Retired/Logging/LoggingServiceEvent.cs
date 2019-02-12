using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Useful.Remoting;

namespace Useful.Services.Clients
{
    /// <summary>
    /// An event raised by the logging service.
    /// </summary>
	internal class LoggingServiceEvent : RemoteEvent
	{
        /// <summary>
        /// An event for notification that a message has arrived.
        /// </summary>
		public event EventHandler<MessageArrivedEventArgs> MessageArrivedLocally;

        // don't use OneWay here!
        /// <summary>
        /// A message arrived event handler.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The data for the event.</param>
        public void LocallyHandleMessageArrived(object sender, MessageArrivedEventArgs e)
        {
            // forward the message to the client
            MessageArrivedLocally(this, e);
        }

        //event EventHandler<EventArgs> NewLine;

        //void WriteLine(string line);

        //string GetLog();
	}
}
