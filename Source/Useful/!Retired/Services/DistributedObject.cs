using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.Net.Sockets;

namespace Useful.Remoting
{
    /// <summary>
    /// A base class used for broadcasting of remoting events.
    /// </summary>
    public abstract class RemoteEventBroadcaster : MarshalByRefObject, IRemoteService
    {
        readonly DateTime m_creationTime = DateTime.Now;
        // private field to store number of connected users
        private int m_connected;

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        protected RemoteEventBroadcaster()
        {
            // Update the count of connected users
            m_connected++;
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

        /// <summary>
        /// Returns confirmation if the service is working.
        /// </summary>
        public bool Test()
        {
            return true;
        }

        /// <summary>
        /// Return the physical path from which the component is running.
        /// </summary>
        public string CodeBase
        {
            get
            {
                AssemblyInfo ainfo = new AssemblyInfo(this);
                return ainfo.CodeBase;
            }
        }

        /// <summary>
        /// Returns the assembly's fully qualified name.
        /// </summary>
        public string FullyQualifiedName
        {
            get
            {
                AssemblyInfo ainfo = new AssemblyInfo(this);
                return ainfo.AssemblyFullyQualifiedName;
            }
        }

        /// <summary>
        /// Returns when the current object instance was created.
        /// </summary>
        public DateTime CreationTime
        {
            get
            {
                return m_creationTime;
            }
        }

        /// <summary>
        /// Returns the name of the machine that the object is running on.
        /// </summary>
        public string HostName
        {
            get
            {
                return System.Environment.MachineName;
            }
        }

        /// <summary>
        /// Returns the current number of clients connected to this object.
        /// </summary>
        public int ConnectionCount
        {
            get
            {
                return m_connected;
            }
        }

        /// <summary>
        /// Releases the resources used by this component.
        /// </summary>
        public void Dispose()
        {
            // When a client correctly lets us go, we can lower our count.
            m_connected--;
        }
    }
}
