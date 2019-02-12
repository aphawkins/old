using System;

namespace Useful.DataServices
{
	/// <summary>
	/// Summary description for Debug.
	/// </summary>
	internal static class Debug
	{
		internal enum Module
		{
			DataService,
			FileWatcher,
			QueueWatcher,
			Error,
			Subscription
		}

		internal static void Print(Module module, string message)
		{
			string moduleName = "";
			switch (module)
			{
				case (Module.DataService):
				{
					if (true)
					{
						moduleName = "DataService";
						Write(moduleName, message);
					}
					break;
				}
				case (Module.FileWatcher):
				{
					if (true)
					{
						moduleName = "FileWatcher";
						Write(moduleName, message);
					}
					break;
				}
				case (Module.QueueWatcher):
				{
					if (true)
					{
						moduleName = "QueueWatcher";
						Write(moduleName, message);
					}
					break;
				}
				case (Module.Error):
				{
					if (true)
					{
						moduleName = "Error - See Event Log";
						Write(moduleName, message);
					}
					break;
				}
				case (Module.Subscription):
				{
					if (true)
					{
						moduleName = "Subscription";
						Write(moduleName, message);
					}
					break;
				}

				default:
				{
					if (true)
					{
						moduleName = "Unknown";
						Write(moduleName, message);
					}
					break;
				}
			}
		}

        private static void Write(string moduleName, string message)
        {
            Console.WriteLine(moduleName + ": " + message);
        }
	}
}
