using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;
using System.Globalization;
using System.Timers;
using System.Net.Sockets;

using Useful.Services;
using Useful.Remoting;
using Useful.Services.Clients;

namespace Useful.Remoting
{
    /// <summary>
    /// A base class for a remoting client.
    /// </summary>
	public abstract class RemoteClient
	{
		int serverPort;
		int clientPort;
		Type remoteType;
		string hostName;
		ServiceState serviceState;
        bool useConfig;
        bool useSecurity;
        CultureInfo culture = new CultureInfo("en-GB");
		Timer servicePoll;
		TcpChannel channel;
		ServiceType serviceType;

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		/// <param name="serviceType">The type of servce to connect to.</param>
		internal RemoteClient(ServiceType serviceType)
		{
			this.serviceType = serviceType;
			servicePoll = new Timer((double)10000);
			servicePoll.Elapsed += new ElapsedEventHandler(servicePoll_Elapsed);
		}

		/// <summary>
		/// A notification when the state of the service is changed.
		/// </summary>
		public event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged;

        /// <summary>
        /// Gets or sets whether this client uses a configuration file to get the service details.
        /// </summary>
        internal protected bool UseConfig
        {
            get { return this.useConfig; }
            set { this.useConfig = value; }
        }

        /// <summary>
        /// Gets or sets whether this client uses security to access the service.
        /// </summary>
        internal protected bool UseSecurity
        {
            get { return this.useSecurity; }
            set { this.useSecurity = value; }
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
        /// Gets or sets whether this client is connected to the service.
        /// </summary>
		public ServiceState ServiceState
		{
			get { return this.serviceState; }
			internal set { this.serviceState = value; }
		}

        /// <summary>
        /// Gets or sets the host name of the server the service is on and this client connects to.
        /// </summary>
		internal protected string HostName
		{
			get { return this.hostName; }
			set { this.hostName = value; }
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
        /// Gets or sets the port number this client uses to connect to the service.
        /// </summary>
		internal protected int ClientPort
		{
			get { return this.clientPort; }
			set { this.clientPort = value; }
		}

		/// <summary>
		/// The type of service this is a client for.
		/// </summary>
		internal protected ServiceType Service
		{
			get { return this.serviceType; }
			set { this.serviceType = value; }
		}

        /// <summary>
        /// Gets the URI for the service.
        /// </summary>
        internal protected Uri ServiceUri
        {
            get
            {
                Uri url = new Uri("tcp://" + this.hostName + ":" + this.serverPort.ToString(this.culture) + "/" + this.serviceType.ToString());
                return url;
            }
        }

		void servicePoll_Elapsed(object sender, ElapsedEventArgs e)
		{
			TestServiceState();
		}

        /// <summary>
        /// Connects to the remote service.
        /// </summary>
		internal void Initialize()
		{
			if (!this.useConfig)
			{
                // Don't use the config file
				BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
				BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
				serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
				System.Collections.IDictionary properties = new Dictionary<string, object>();
				properties["name"] = System.Guid.NewGuid().ToString();
				properties["port"] = this.clientPort;
				properties["typeFilterLevel"] = TypeFilterLevel.Full;
				channel = new TcpChannel(properties, clientProvider, serverProvider);
				if (ChannelServices.GetChannel(this.channel.ToString()) == null)
				{
                    ChannelServices.RegisterChannel(this.channel, this.useSecurity);
				}
			}
			else
			{
                // Use the config file
				//String filename = "eventlistener.exe.config";
				//RemotingConfiguration.Configure(filename);
				//broadcaster = (IEventBroadcaster)RemotingHelper.GetObject(typeof(IEventBroadcaster));
			}
			servicePoll.Start();
			//RemotingConfiguration.ApplicationName = "Broadcaster.soap";
		}

		/// <summary>
		/// Disconnects from the remote service.
		/// </summary>
		public virtual void Disconnect()
		{
			if (!this.useConfig)
			{
				// Unregistering the channel doesn't work correctly
				ChannelServices.UnregisterChannel(this.channel);
			}
			servicePoll.Stop();
		}
        
        internal object RemoteObject
        {
			get
			{
				TestServiceState();
				return Activator.GetObject(this.remoteType, this.ServiceUri.ToString());
			}
        }

		internal void CheckConnection()
		{
			if (this.serviceState != ServiceState.Available)
			{
				throw new ServiceNotAvailableException();
			}
		}

		internal void TestServiceState()
		{
			IRemoteService remoteService = (IRemoteService)Activator.GetObject(typeof(IRemoteService), this.ServiceUri.ToString());
			try
			{
				// Can we see the service?
				bool test = remoteService.Test();

				// Service is reachable
				if (this.serviceState != ServiceState.Available)
				{
					this.serviceState = ServiceState.Available;
					OnServiceStateChanged(ServiceState.Available);
				}
			}
			catch
			{

				// Service is unreachable
				if (this.serviceState != ServiceState.Unavailable)
				{
					this.serviceState = ServiceState.Unavailable;
					OnServiceStateChanged(ServiceState.Unavailable);
				}
			}

		}

		private void OnServiceStateChanged(ServiceState serviceState)
		{
			if (ServiceStateChanged != null)
			{
				ServiceStateChanged(this, new ServiceStateChangedEventArgs(serviceState));
			}
		}
	}
}
