using System;
using System.Collections.Generic;
using System.Text;

using Useful.Remoting;

namespace Useful.Services.Clients
{
    /// <summary>
    /// An interface between the Time client and server.
    /// </summary>
	public interface ITimeService
	{
        /// <summary>
        /// Broadcasts the time.
        /// </summary>
        /// <param name="time">The time to broadcast.</param>
		void BroadcastTime(DateTime time);

        /// <summary>
        /// An event for notification that the time has arrived.
        /// </summary>
		event EventHandler<TimeArrivedEventArgs> TimeArrived;
	}
}
