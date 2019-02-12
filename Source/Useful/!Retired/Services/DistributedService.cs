using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Runtime.Serialization.Formatters;

using Useful.Services;

namespace Useful.Services
{
	// Define the event                                                     
	//public delegate void ServerEventHandler(object sender, RemoteEventArgs e);

    /// <summary>
    /// A base class for a remoting server.
    /// </summary>
	public class DistributedService
	{
		int serverPort;
		Type remoteType;
		WellKnownObjectMode mode;
        bool useConfig;
        bool useSecurity;
		MarshalByRefObject remoteObj;
		TcpChannel channel;
		ServiceType serviceType;
		bool isChannelOpen;

		/// <summary>
		/// Creates an instance of this class.
		/// </summary>
		/// <param name="service">The type of service to create.</param>
		public DistributedService(ServiceType service)
		{
			this.serviceType = service;

			switch (service)
			{
				case (ServiceType.Logging):
					{
						this.serverPort = 9000;
						this.mode = WellKnownObjectMode.Singleton;
						this.remoteType = typeof(DistributedLoggingObject);
						this.useSecurity = false;
						this.remoteObj = new DistributedLoggingObject();
						break;
					}
				case (ServiceType.Time):
					{
						this.serverPort = 9001;
						this.mode = WellKnownObjectMode.Singleton;
						this.remoteType = typeof(DistributedTimeObject);
						this.useSecurity = false;
						this.remoteObj = new DistributedTimeObject();
						break;
					}
				default:
					{
						throw new DistributedServiceException(string.Format("Unknown service {0}", service.ToString()));
					}
			}
		}

        /// <summary>
        /// Gets or sets whether this service uses a configuration file to get the service details.
        /// </summary>
        internal protected bool UseConfig
        {
            get { return this.useConfig; }
			set { this.useConfig = value; }
        }

        /// <summary>
        /// Gets or sets whether this service uses security.
        /// </summary>
        internal protected bool UseSecurity
        {
			get { return this.useSecurity; }
			set { this.useSecurity = value; }
        }

        /// <summary>
        /// The activation mode of the well-known object type being registered.
        /// </summary>
        internal protected WellKnownObjectMode Mode
		{
			get { return this.mode; }
			set { this.mode = value; }
        }

        /// <summary>
        /// Gets or sets the remote type client connects to the service with.
        /// </summary>
		internal protected Type RemoteType
		{
			get { return this.remoteType; }
			set { this.remoteType = value; }
		}

        /// <summary>
        /// Gets or sets the port number the service uses to connect to this client.
        /// </summary>
		internal protected int ServerPort
		{
			get { return this.serverPort; }
			set { this.serverPort = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public MarshalByRefObject Obj
		{
			get { return this.remoteObj; }
			set { this.remoteObj = value; }
		}

        /// <summary>
        /// Starts the service.
        /// </summary>
		public virtual void Start()
		{
			if (!this.useConfig)
			{
				BinaryClientFormatterSinkProvider clientProvider = null;
				BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
				serverProvider.TypeFilterLevel = TypeFilterLevel.Full;
				if (!this.isChannelOpen)
				{
					System.Collections.IDictionary properties = new Dictionary<string, object>();
					properties["name"] = serverPort.ToString();	// System.Guid.NewGuid().ToString(); ;
					properties["port"] = serverPort;
					properties["typeFilterLevel"] = TypeFilterLevel.Full;
					channel = new TcpChannel(properties, clientProvider, serverProvider);
					if (ChannelServices.GetChannel(channel.ToString()) == null)
					{
						ChannelServices.RegisterChannel(channel, useSecurity);
						this.isChannelOpen = true;
					}
				}
				//RemotingConfiguration.RegisterWellKnownServiceType(m_remoteType, m_serviceName, m_mode);
				RemotingServices.Marshal(remoteObj, this.serviceType.ToString(), remoteType);
			}
			else
			{
				//String filename = "server.exe.config";
				//RemotingConfiguration.Configure(filename);
			}
			//Log("Server started.");
		}

		/// <summary>
		/// Stops the service.
		/// </summary>
		public virtual void Stop()
		{
			if (!useConfig)
			{
				RemotingServices.Disconnect(this.remoteObj);
				// Unregistering the channel doesn't work correctly
				// ChannelServices.UnregisterChannel(tcpChannel);
			}
			else
			{
				//String filename = "server.exe.config";
				//RemotingConfiguration.Configure(filename);
			}
			//Log("Server stopped.");
		}

        /*
        // This function iterates through all the ClientActivatedService types
		// that were loaded via the RemotingConfiguration.Configure(Remoting.config)
		// file.
		private static ArrayList ListClientActivatedServiceTypes()
		{
			ArrayList types = new ArrayList();

			foreach (ActivatedServiceTypeEntry entry in RemotingConfiguration.GetRegisteredActivatedServiceTypes())
			{
				types.Add("Registered ActivatedServiceType: " + entry.TypeName);
			}

			return types;
		}

		// This function iterates through all the WellKnownService types
		// that were loaded via the RemotingConfiguration.Configure(Remoting.config)
		// file.
		private static ArrayList ListWellKnownServiceTypes()
		{
			ArrayList types = new ArrayList();

			foreach (WellKnownServiceTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownServiceTypes())
			{
				types.Add(entry.TypeName + " is available at " + entry.ObjectUri);
			}

			return types;
		}
        */
	}
}
