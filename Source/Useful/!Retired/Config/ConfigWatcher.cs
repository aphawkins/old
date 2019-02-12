using System;
using System.Xml;
using System.Xml.XPath;
using System.Configuration;
using System.IO;
using System.Globalization;
using System.Xml.Serialization;

namespace Useful.Config
{
	/// <summary>
	/// Contains functionality for watching the config file for changes.
	/// </summary>
	public class ConfigWatcher : IDisposable
	{
        /// <summary>
        /// An event to notify that the configuration has changed.
        /// </summary>
        public event EventHandler<ConfigChangedEventArgs> Changed;

		UsefulConfig m_config;
        string m_configPath;
        FileSystemWatcher m_watcher;

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public ConfigWatcher()
		{
			#region Config schema
			// Look for the schema file
			AssemblyInfo info = new AssemblyInfo(this);
			FileInfo assemblyFile = new FileInfo(info.Location);
			string schemaPath = Path.Combine(assemblyFile.DirectoryName, "Useful.Config.xsd");

			if (!File.Exists(schemaPath))
			{
				throw new ConfigurationException(Resource.NoConfigSchema);
			}
			#endregion

			#region Config file
			try
			{
				// Get the XML schema config file for reading
				m_configPath = ConfigurationManager.AppSettings["ConfigPath"];

				// Is there a value for the config in the app.config file?
				if (m_configPath == null)
				{
					throw new ConfigurationException(Resource.NoConfigPath);
				}

				// Does the config directory exist?
				if (!Directory.Exists(m_configPath))
				{
					throw new ConfigurationException(Resource.NoConfigDir);
				}

				// Add the name of the config file to the directory
				m_configPath = Path.Combine(m_configPath, "Useful.Config.xml");

				// Does the config file exist?
				if (!File.Exists(m_configPath))
				{
					throw new ConfigurationException(Resource.NoConfigFile);
				}
			}
			catch (ConfigurationErrorsException ex)
			{
				throw new ConfigurationException(Resource.ConfigSysError, ex);
			}
			#endregion

			// Read the config file
			Read();

			// Set up the watcher to watch the config file for changes
			// TODO: Test this
			CreateWatcher();
		}

		#region properties

		internal UsefulConfig Config
		{
			get { return m_config; }
		}

		#endregion

		#region Events
		private void OnConfigChanged(ConfigChangedEventArgs e)
		{
			if (Changed != null) 
			{
				// Invokes the delegates. 
				Changed(this, e);
			}
		}
		#endregion

		private void Read()
		{
			try
            {
                // Construct an instance of the XmlSerializer with the type of object that is being deserialized.
				XmlSerializer mySerializer = new XmlSerializer(typeof(UsefulConfig));

				// To read the file, create a FileStream
				FileStream fsConfig = new FileStream(m_configPath, FileMode.Open);
				
                // Call the Deserialize method and cast to the object type.
				m_config = (UsefulConfig)mySerializer.Deserialize(fsConfig);

                // Close the config file
                if (fsConfig != null)
                {
                    fsConfig.Close();
                }
			}
			catch
			{
                throw new Useful.Config.ConfigurationException(Resource.ConfigReadError);
			}
		}

		private void CreateWatcher()
		{
			m_watcher = new FileSystemWatcher();
			m_watcher.EnableRaisingEvents = true;
			m_watcher.Filter = "*.xml";
			m_watcher.IncludeSubdirectories = false;
			m_watcher.NotifyFilter = NotifyFilters.LastWrite;
			m_watcher.Path = m_configPath;
			m_watcher.Changed += new FileSystemEventHandler(m_watcher_Changed);
		}

		void m_watcher_Changed(object sender, FileSystemEventArgs e)
		{
			OnConfigChanged(new ConfigChangedEventArgs());
		}

        #region IDisposable Members

		/// <summary>
		/// Releases all resources used by this object.
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
				if (m_watcher != null)
				{
					m_watcher.Dispose();
				}
			}
		}

        #endregion
    }
}
