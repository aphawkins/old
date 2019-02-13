using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.Services
{
	/// <summary>
	/// The state a service can be in.
	/// </summary>
	public enum ServiceState
	{
		/// <summary>
		/// The service is available.
		/// </summary>
		Available,

		/// <summary>
		/// The service is unavailable.
		/// </summary>
		Unavailable
	}
}
