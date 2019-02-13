using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.DataServices
{
	internal delegate void ExportedEventHandler(object sender, ExportedEventArgs e);

	internal class ExportedEventArgs : EventArgs
	{
		private readonly string m_xml;

		internal ExportedEventArgs(string xml)
		{
			m_xml = xml;
		}

		//Properties.
		internal string XML
		{
			get
			{
				return m_xml;
			}
		}
	}
}
