using System;

namespace Useful.DataServices.Interfaces
{
	/// <summary>
	/// APH HR Data Services Import data interface.
	/// </summary>
	public interface IImport
	{
		/// <summary>
		/// Imports a APH HR standard schema XML data.
		/// </summary>
		/// <param name="cid">Company Id to import into.</param>
		/// <param name="xmlData">The XML to be imported, which corresponds to a standard schema.</param>
		/// <returns>Sucessful import as boolean.</returns>
		bool ImportXml(int cid, string xmlData);

		/// <summary>
		/// Error messages as XML data.  Empty string if there are no errors.
		/// </summary>
		string[] Errors
		{
			get;
		}
	}

	/// <summary>
	/// APH HR Data Services Export data interface.
	/// </summary>
	public interface IExport
	{
		/// <summary>
		/// Exports a APH HR standard schema XML data.
		/// </summary>
		/// <param name="cid">Company Id from which to export data from.</param>
		/// <param name="xmlCommand">A standard XML schema command defining the data to export.</param>
		/// <returns>The XML exported from the system, which corresponds to a standard schema.  Empty string if there are any errors.</returns>
		string ExportXml(int cid, string xmlCommand);
	
		/// <summary>
		/// Error messages as XML data.  Empty string if there are no errors.
		/// </summary>
		string[] Errors
		{
			get;
		}
	}
}
