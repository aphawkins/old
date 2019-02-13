using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Useful.DataServices
{
	internal class ImportedEventArgs : EventArgs
	{
		private readonly TextReader m_stream;
        private readonly string m_consumer;

		internal ImportedEventArgs(string consumer, TextReader stream)
		{
		    m_stream = stream;
            m_consumer = consumer;
		}

		internal TextReader Stream
		{
		    get
		    {
		        return m_stream;
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
