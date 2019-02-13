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
    /// Used for broadcasting of logging events.
    /// </summary>
	public class DistributedLoggingObject : RemoteEventBroadcaster, ILoggingService
	{
        /// <summary>
        /// An event for notification that a message has arrived.
        /// </summary>
		public event EventHandler<MessageArrivedEventArgs> MessageArrived;

        /// <summary>
        /// Broadcasts a message.
        /// </summary>
        /// <param name="message">The message to send.</param>
		public void BroadcastMessage(string message)
		{
			//Log("Will broadcast message: {0}", msg);
			SafeInvokeEvent(message);
		}

		private void SafeInvokeEvent(string message)
		{
			// call the delegates manually to remove them if they aren't
			// active anymore.

			if (MessageArrived == null)
			{
				//Log("No listeners");
			}
			else
			{
				//Log("Number of Listeners: {0}", MessageArrived.GetInvocationList().Length);
				EventHandler<MessageArrivedEventArgs> messageHandler = null;

				foreach (Delegate messageDelegate in MessageArrived.GetInvocationList())
				{
					try
					{
						messageHandler = (EventHandler<MessageArrivedEventArgs>)messageDelegate;
						messageHandler(this, new MessageArrivedEventArgs(message));
					}
					catch (SocketException)
					{
						//Log("Exception occured, will remove Delegate");
						MessageArrived -= messageHandler;
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
