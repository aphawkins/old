using System;

namespace Useful.DataServices
{
	/// <summary>
	/// Summary description for WatcherBase.
	/// </summary>
	internal abstract class WatcherBase
	{
		#region Events
        //internal protected event EventHandler<ImportedEventArgs> Imported;
		//internal protected event ExportedEventHandler Exported;

        //internal protected void OnImport(ImportedEventArgs e)
        //{
        //    if (Imported != null) 
        //    {
        //        // Invokes the delegates. 
        //        Imported(this, e);
        //    }
        //}

		//internal protected void OnExport(ExportedEventArgs e)
		//{
		//    if (Exported != null) 
		//    {
		//        // Invokes the delegates. 
		//        Exported(this, e);
		//    }
		//}

		#endregion

		internal abstract void Start();
	}
}
