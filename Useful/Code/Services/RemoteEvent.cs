using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;

namespace Useful.Remoting
{
    /// <summary>
    /// A base class for creating remoting events.
    /// </summary>
	public abstract class RemoteEvent : MarshalByRefObject
	{
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
