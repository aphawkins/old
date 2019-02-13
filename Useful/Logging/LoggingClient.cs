using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net.Sockets;
using System.Threading;

using Useful.Remoting;

namespace Useful.Services.Clients
{
    /// <summary>
    /// A base class for a logging client.
    /// </summary>
	public sealed class LoggingClient : RemoteClient, ILoggingService
	{
        string lastMessage;
		LoggingServiceEvent eventWrapper;
		bool handlerAdded;
        Thread messageArrivedThread;
        string message;

		/// <summary>
		/// This event is raised when a new message arrives.
		/// </summary>
		public event EventHandler<MessageArrivedEventArgs> MessageArrived;

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public LoggingClient() : base(ServiceType.Logging)
		{
            base.ServerPort = 9000;
            base.ClientPort = 0;
            base.HostName = "192.168.1.64";
            base.UseSecurity = false;
            base.RemoteType = typeof(ILoggingService);
			base.ServiceStateChanged += new EventHandler<ServiceStateChangedEventArgs>(LoggingClient_ServiceStateChanged);

			Initialize();
		}

		void LoggingClient_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
		{
			switch (e.NewServiceState)
			{
				case ServiceState.Available:
					{
						if (!this.handlerAdded)
						{
							// register the local handler with the "remote" handler
							eventWrapper.MessageArrivedLocally += new EventHandler<MessageArrivedEventArgs>(OnMessageArrived);
							((ILoggingService)RemoteObject).MessageArrived += new EventHandler<MessageArrivedEventArgs>(eventWrapper.LocallyHandleMessageArrived);
							this.handlerAdded = true;
						}
						break;
					}
				case ServiceState.Unavailable:
					{
						// register the local handler with the "remote" handler
						// ((ILoggingService)RemoteObject).MessageArrived -= new EventHandler<MessageArrivedEventArgs>(eventWrapper.LocallyHandleMessageArrived);
						// eventWrapper.MessageArrivedLocally -= new EventHandler<MessageArrivedEventArgs>(OnMessageArrived);
						break;
					}
			}

		}

        /// <summary>
        /// Gets or sets the message to send.
        /// </summary>
        public string LastMessage
        {
            get { return this.lastMessage; }
            set { this.lastMessage = value; }
        }

        /// <summary>
        /// Handles a Message Arrived event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The data for the event.</param>
		private void OnMessageArrived(object sender, MessageArrivedEventArgs e)
		{
            //Log("Received: {0}", msg);
            
            this.message = e.Message;

            this.messageArrivedThread = new Thread(new ThreadStart(this.OnMessageArrived));
            this.messageArrivedThread.Start();
		}

        /// <summary>
        /// Connects to the remote service.
        /// </summary>
        private new void Initialize()
        {
			try
			{
				base.Initialize();

				//Log("Press to listen...");

				// this one will be created in the client's context and a 
				// reference will be passed to the server
				eventWrapper = new LoggingServiceEvent();

				// register the local handler with the "remote" handler
				// eventWrapper.MessageArrivedLocally += new EventHandler<MessageArrivedEventArgs>(OnMessageArrived);

				//Log("Registering event at server");
				// ((ILoggingService)RemoteObject).MessageArrived += new EventHandler<MessageArrivedEventArgs>(eventWrapper.LocallyHandleMessageArrived);

				//Log("Event registered. Waiting for messages.");
			}
			catch (SocketException ex)
			{
				// Log.Writeline("Connection to Logging service failed. " + ex.ToString())
				System.Diagnostics.Debug.WriteLine(ex.ToString());

				base.ServiceState = ServiceState.Unavailable;
			}
        }

		/// <summary>
		/// Disconnects from the remote logging service.
		/// </summary>
		public override void Disconnect()
		{
			base.Disconnect();
		}


		/// <summary>
		/// Broadcasts a message.
		/// </summary>
		/// <param name="message">The message to broadcast.</param>
		public void BroadcastMessage(string message)
		{
			base.CheckConnection();

			((ILoggingService)RemoteObject).BroadcastMessage(message);
		}

        private void OnMessageArrived()
        {
            if (MessageArrived != null)
            {
                MessageArrived(this, new MessageArrivedEventArgs(this.message));
            }
        }
	}
}
