using System;
using System.Collections.Generic;
using System.Text;

using Useful.Remoting;

namespace Useful.Services.Clients
{
    /// <summary>
    /// An interface between logging client and server.
    /// </summary>
	public interface ILoggingService
	{
        /// <summary>
        /// Broadcasts a message.
        /// </summary>
        /// <param name="message">The message to broadcast.</param>
		void BroadcastMessage(string message);

        /// <summary>
        /// An event for notification that a message has arrived.
        /// </summary>
		event EventHandler<MessageArrivedEventArgs> MessageArrived;
	}
}
