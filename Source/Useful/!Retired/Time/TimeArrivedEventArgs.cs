using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.Services.Clients
{
    /// <summary>
    /// Used for notification that the time has arrived.
    /// </summary>
    [Serializable]
    public class TimeArrivedEventArgs : EventArgs
    {
        private DateTime time;

        /// <summary>
        /// Provides data for the Time Arrived event. 
        /// </summary>
		/// <param name="dateTime">The time to send.</param>
        public TimeArrivedEventArgs(DateTime dateTime)
		{
			this.time = dateTime;
		}

        /// <summary>
        /// The time to send.
        /// </summary>
        public DateTime Time
        {
            get
            {
                return this.time;
            }
        }

    }
}
