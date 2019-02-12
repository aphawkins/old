using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections.Generic;

namespace Useful.Remoting.ServiceController
{
	public interface IServiceController : IRemoteType
	{
		bool Test{ get; }

		bool StartLogging();
	}
}
