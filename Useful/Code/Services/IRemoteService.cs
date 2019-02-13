using System;
using System.Collections.Generic;
using System.Text;

using Useful.Services;

namespace Useful.Remoting
{
    /// <summary>
    /// An interface between remoting client and server.
    /// </summary>
	public interface IRemoteService
	{
        /// <summary>
        /// Returns confirmation if the service is working.
        /// </summary>
        bool Test();

        /// <summary>
        /// Return the physical path from which the component is running.
        /// </summary>
        string CodeBase { get; }

        /// <summary>
        /// Returns the assembly's fully qualified name.
        /// </summary>
        string FullyQualifiedName { get; }

        /// <summary>
        /// Returns when the current object instance was created.
        /// </summary>
        DateTime CreationTime { get; }

        /// <summary>
        /// Returns the name of the machine that the object is running on.
        /// </summary>
        string HostName { get; }

        /// <summary>
        /// Returns the current number of clients connected to this object.
        /// </summary>
        int ConnectionCount { get; }
	}
}
