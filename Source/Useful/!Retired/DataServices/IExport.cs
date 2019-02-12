using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Useful.DataServices
{
	/// <summary>
	/// Useful Data Services Export data interface.
	/// </summary>
	public interface IExport
	{
		/// <summary>
		/// Exports a Useful standard schema XML data.
		/// </summary>
		/// <param name="cid">Company Id from which to export data from.</param>
		/// <param name="xmlCommand">A standard XML schema command defining the data to export.</param>
		/// <returns>The XML exported from the system, which corresponds to a standard schema.  Empty string if there are any errors.</returns>
		string ExportXml(int cid, string xmlCommand);

		/// <summary>
		/// Error messages as XML data.  Empty string if there are no errors.
		/// </summary>
		Collection<string> Errors
		{
			get;
		}
	}
}
