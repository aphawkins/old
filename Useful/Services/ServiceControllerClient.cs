using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Useful.Remoting.ServiceController
{
	public class ServiceControllerClient : RemoteClientBase
	{
		public ServiceControllerClient()
		{
			base.Port = 9000;
			base.HostName = "zeus";
			base.ServiceName = "ServiceControllerService";
		}

		public IServiceController RemoteType
		{
			get
			{
				return (IServiceController)base.GetRemoteType;
			}
		}
	}
}
