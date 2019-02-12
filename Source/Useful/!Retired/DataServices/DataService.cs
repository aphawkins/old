using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Xml.XPath;
using System.Data.SqlClient;

using Useful;
using Useful.Config;

namespace Useful.DataServices
{
	/// <summary>
	/// A class for creating a data service.
	/// </summary>
	public class DataService : IDisposable
	{
		ConfigWatcher configWatch;
		//Subscription m_subscription;
		FileWatcher fileWatch;
		QueueWatcher queueWatcher;
		//DataStore m_datastore;

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public DataService()
		{
		}

        /// <summary>
        /// Starts this service.
        /// </summary>
		public void Start()
		{
			try
			{
				// Start Config Watcher
				this.configWatch = new ConfigWatcher();
				this.configWatch.Changed += new EventHandler<ConfigChangedEventArgs>(this.Config_Changed);

				UsefulConfigConsumer config = this.configWatch.Config.Consumers[0];

				// Start Datastore
				//m_datastore = new DataStore();
				//m_datastore.ProcessSuccess += new EventHandler<DataStoreEventArgs>(m_datastore_ProcessSuccess);

				// Start Subscription
				//m_subscription = new Subscription(m_config.Subscriptions);
				//m_subscription.Start();
			
				// Start File Watcher
				this.fileWatch = new FileWatcher(config.Name, config.DataService.File);
                //this.fileWatch.Imported += new EventHandler<ImportedEventArgs>(this.Stream_Imported);
				this.fileWatch.Start();

				//// Start Queue Watcher
				this.queueWatcher = new QueueWatcher(config.Name, config.DataService.Queue);
                //this.queueWatcher.Imported += new EventHandler<ImportedEventArgs>(this.Stream_Imported);
				this.queueWatcher.Start();

				// TODO: Start Other Watchers
			}
			catch
			{
				throw;
				//Error.Raise(Ex);
			}
		}

		//void m_datastore_ProcessSuccess(object sender, DataStoreEventArgs e)
		//{
		//    if (this.configWatch.Config.Consumers[0].DataService.Transport.Success == Transport.File)
		//    {
		//        //this.fileWatch.OnImport
		//    }
		//    throw new NotImplementedException(Resource.MethodNotImplemented);
		//}

        /// <summary>
        /// Stops this service.
        /// </summary>
		public void Stop()
		{
			// reverse order of creation
			this.queueWatcher = null;
			this.fileWatch = null;
			//m_subscription = null;
			this.configWatch = null;
		}

		private void Config_Changed(object sender, ConfigChangedEventArgs e)
		{
			ConfigChanges();
		}

        //private void Stream_Imported(object sender, ImportedEventArgs e)
        //{
			// Save stream
			//m_datastore.AddItem(e.Stream, e.Consumer);
        //}

		private void ConfigChanges()
		{
			// Change Subscription Config

			// Change FileWatcher parameters
			this.fileWatch.Config = this.configWatch.Config.Consumers[0].DataService.File;

			// Change QueueWatcher parameters
			this.queueWatcher.Config = this.configWatch.Config.Consumers[0].DataService.Queue;

			// Change OtherWatcher parameters

			// Change DataSevices config
		}

		#region IDisposable Members

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected virtual void Dispose(bool disposing)
		{
			// A call to Dispose(false) should only clean up native resources. 
			// A call to Dispose(true) should clean up both managed and native resources.
			if (disposing)
			{
				if (this.configWatch != null)
				{
					this.configWatch.Dispose();
				}
			}
		}

		#endregion
	}
}
