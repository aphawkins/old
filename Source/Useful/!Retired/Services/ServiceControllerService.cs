using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;
using System.Collections.Generic;

using Useful.Remoting.Logging;

namespace Useful.Remoting.ServiceController
{
	public class ServiceControllerService : RemoteServerBase, IServiceController
	{
		System.Collections.Generic.Dictionary<string, string> m_services;
		LoggingClient m_logging;

		public ServiceControllerService()
		{
			base.Port = 9000;
			base.RemoteType = typeof(IServiceController);
			base.ServiceName = "ServiceControllerService";
			base.Mode = WellKnownObjectMode.SingleCall;

			m_services = new Dictionary<string, string>();
		}

		public bool StartLogging()
		{
			m_logging = new LoggingClient();
			m_logging.Connect();
			m_logging.RemoteType.WriteLine("service controller log line.");
			return m_logging.IsConnected;
		}

		public void TestLogging()
		{
			m_logging.RemoteType.WriteLine("hello");
		}

		public bool Test
		{
			get
			{
				return true;
			}
		}

		public void RegisterService(string url, string serviceName)
		{
			if (m_services.ContainsKey(url))
			{
				m_services.Remove(url);
			}
			m_services.Add(url, serviceName);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns>The URL of the service.</returns>
		public string LocateService(string serviceName)
		{
			string url = null;

			foreach (KeyValuePair<string, string> service in m_services)
			{
				if (service.Value == serviceName)
				{
					url = service.Key;
					break;
				}
			}

			return url;
		}
	}
}
