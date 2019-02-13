using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.Net.Sockets;

using Useful.Remoting;
using Useful.Services.Clients;

namespace Useful.Services
{
    /// <summary>
    /// Used for broadcasting of time events.
    /// </summary>
	public class DistributedTimeObject : RemoteEventBroadcaster, ITimeService
	{
        /// <summary>
        /// An event for notification that the time has arrived.
        /// </summary>
		public event EventHandler<TimeArrivedEventArgs> TimeArrived;

        /// <summary>
        /// Broadcasts the time.
        /// </summary>
		/// <param name="time">The time to send.</param>
		public void BroadcastTime(DateTime time)
		{
			//Log("Will broadcast message: {0}", msg);
			SafeInvokeEvent(time);
		}

		private void SafeInvokeEvent(DateTime time)
		{
			// call the delegates manually to remove them if they aren't
			// active anymore.

			if (TimeArrived == null)
			{
				//Log("No listeners");
			}
			else
			{
				//Log("Number of Listeners: {0}", MessageArrived.GetInvocationList().Length);
				EventHandler<TimeArrivedEventArgs> timeHandler = null;

				foreach (Delegate timeDelegate in TimeArrived.GetInvocationList())
				{
					try
					{
						timeHandler = (EventHandler<TimeArrivedEventArgs>)timeDelegate;
						timeHandler(this, new TimeArrivedEventArgs(time));
					}
					catch (SocketException)
					{
						//Log("Exception occured, will remove Delegate");
						TimeArrived -= timeHandler;
					}
				}
			}
		}

        /// <summary>
        /// Gives this an infinite lifetime by preventing a lease from being created.
        /// </summary>
        /// <returns>Always a null reference.</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
		public override object InitializeLifetimeService()
		{
			// this object has to live "forever"
			return null;
		}
	}
}
