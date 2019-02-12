using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.Services.Clients
{
    /// <summary>
    /// Used for notification that a service state has changed.
    /// </summary>
    [Serializable]
    public class ServiceStateChangedEventArgs : EventArgs
    {
        private ServiceState newServiceState;

        /// <summary>
        /// Provides data for the event. 
        /// </summary>
		/// <param name="serviceState">The new state.</param>
		public ServiceStateChangedEventArgs(ServiceState serviceState)
		{
			this.newServiceState = serviceState;
		}

        /// <summary>
        /// The new service state.
        /// </summary>
		public ServiceState NewServiceState
        {
            get
            {
				return this.newServiceState;
            }
        }

    }
}
