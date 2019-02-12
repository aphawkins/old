using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Useful.DataServices
{
	internal class DataStoreEventArgs : EventArgs
	{
		private readonly string m_consumer;
		private readonly int m_id;

		internal DataStoreEventArgs(string consumer, int dataId)
		{
			m_id = dataId;
			m_consumer = consumer;
		}

		internal int DataId
		{
		    get
		    {
		        return m_id;
		    }
		}

		internal string Consumer
		{
		    get
		    {
		        return m_consumer;
		    }
		}
	}
}
