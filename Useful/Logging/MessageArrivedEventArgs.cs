using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.Services.Clients
{
    /// <summary>
    /// Used for notification that a message has arrived.
    /// </summary>
    [Serializable]
    public class MessageArrivedEventArgs : EventArgs
    {
        private string _message;

        /// <summary>
        /// Provides data for the Message Arrived event. 
        /// </summary>
        /// <param name="message">The message to send.</param>
        public MessageArrivedEventArgs(string message)
		{
			this._message = message;
		}

        /// <summary>
        /// The message to send.
        /// </summary>
        public string Message
        {
            get
            {
                return this._message;
            }
        }

    }
}
