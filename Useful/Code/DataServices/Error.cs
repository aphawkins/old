using System;
using System.Diagnostics;

namespace Useful.DataServices
{
	/// <summary>
	/// Summary description for Errors.
	/// </summary>
	internal static class Error
	{	
		internal static void Raise(Exception Ex)
		{
			// Display the error message to the user
			Debug.Print(Debug.Module.Error, Ex.Message);

			//if (!EventLog.Exists("Useful"))
			//{
			//	// Write the whole message to the event log
			//	EventLog.CreateEventSource("Useful Data Service", "Useful");
			//}
			//EventLog.WriteEntry("Useful", "Useful Data Service: " + Ex.ToString());
			EventLog.WriteEntry(Resource.UsefulDataService, Resource.UsefulDataService + ": " + Ex.ToString());
		}
		
	}
}
