using System;
using System.Collections.ObjectModel;

namespace Useful.DataServices
{
	/// <summary>
	/// Useful Data Services Import data interface.
	/// </summary>
	public interface IImport
	{
		/// <summary>
		/// Imports a Useful standard schema XML data.
		/// </summary>
		/// <param name="cid">Company Id to import into.</param>
		/// <param name="xmlData">The XML to be imported, which corresponds to a standard schema.</param>
		/// <returns>Sucessful import as boolean.</returns>
		bool ImportXml(int cid, string xmlData);

		/// <summary>
		/// Error messages as XML data.  Empty string if there are no errors.
		/// </summary>
		Collection<string> Errors
		{
			get;
		}
	}
}
