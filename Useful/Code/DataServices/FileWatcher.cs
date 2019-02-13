using System;
using System.IO;
using System.Timers;
using System.Xml;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Useful.DataServices
{
	internal class FileWatcher : WatcherBase
	{
        //string m_consumer;
		UsefulConfigConsumerDataServiceFile m_config;
		Timer m_timer = new Timer();
		SortedList<string, bool> m_filePaths = new SortedList<string, bool>();
		//CultureInfo m_culture = new CultureInfo("en-GB");

		#region Initialisation
		internal FileWatcher(string consumer, UsefulConfigConsumerDataServiceFile config)
		{
            //m_consumer = consumer;
			m_config = config;
		}

		
		internal override void Start()
		{
			//Debug.Print(Debug.Module.FileWatcher, "Started");

			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = Path.Combine(m_config.Path, "Inbox");
			watcher.Filter = m_config.Filter;
			watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
			watcher.Changed += new FileSystemEventHandler(this.watcher_Changed);
			watcher.Created += new FileSystemEventHandler(this.watcher_Created);
			watcher.EnableRaisingEvents = true;
			watcher.IncludeSubdirectories = true;
			//CheckDirectories();
			CreateTimer();
		}


		internal UsefulConfigConsumerDataServiceFile Config
		{
			set 
			{
				m_config = value;
			}
		}

		#endregion

		#region Timer
		private void CreateTimer()
		{
			//Initialise the time, but don't start it!
			m_timer.Interval = m_config.Timeout;
			m_timer.Elapsed += new System.Timers.ElapsedEventHandler(m_timer_Elapsed);
			m_timer.AutoReset = true;
		}

		private void StartTimer()
		{
			m_timer.Enabled = true;
			//Debug.Print(Debug.Module.FileWatcher, "Timer - Started");
		}

		//private void ResetTimer()
		//{
		//    m_timer.Enabled = false;
		//    m_timer.Enabled = true;
		//}

		private void StopTimer()
		{
			m_timer.Enabled = false;
			m_filePaths.Clear();
			//Debug.Print(Debug.Module.FileWatcher, "Timer - Stopped");
		}

		private bool IsTimerStarted()
		{
			return m_timer.Enabled; 
		}

		private void m_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				//Debug.Print(Debug.Module.FileWatcher, "Timer - Event Raised");

				ProcessModifiedFiles();
			}
			catch
			{
				//Error.Raise(Ex);
				throw;
			}
		}
		#endregion
	
		#region FileSystem Events
		private void watcher_Created(object source, FileSystemEventArgs e) 
		{
			//Debug.Print(Debug.Module.FileWatcher, "File " + e.ChangeType.ToString("G") + " - " + e.FullPath);

			// Check to see if the timer is running
			if (!IsTimerStarted())
			{
				// Start the timer
				StartTimer();
			}

			// Add file to list
			AddFileToList(e.FullPath);
		}

		private void watcher_Changed(object source, FileSystemEventArgs e) 
		{
			// File changed
			FileInfo fa = new FileInfo(e.FullPath);
		
			//Debug.Print(Debug.Module.FileWatcher, "File " + e.ChangeType.ToString("G") + " - " + e.FullPath);
		
			m_filePaths[fa.FullName] = true;
		}
		#endregion

		#region File handling
		private void AddFileToList(string FilePath)
		{
			if (!m_filePaths.ContainsKey(FilePath))
			{
				m_filePaths.Add(FilePath, true);
			}
		}

//		private bool MoveFile(string filePath)
//		{
//			try
//			{
//				string sProcessPath = filePath.Replace(m_paths.ImportPath, m_paths.ProcessedPath);
//				
//				ExecuteMoveFile(filePath, sProcessPath);
//
//				Debug.Print(Debug.Module.FileWatcher, "File moved: " + filePath);
//				return true;
//			}
//			catch(Exception Ex)
//			{
//				throw (Ex);
//			}
//		}

		private static bool DeleteFile(string filePath)
		{
			try
			{		
				File.Delete(filePath);

				//Debug.Print(Debug.Module.FileWatcher, "File deleted: " + filePath);
				return true;
			}
			catch
			{
				throw;
			}
		}

		//private void CheckDirectories()
		//{
		//    string[] subDir = Directory.GetDirectories(m_config.Path);
		//    for (int i = 0 ; i < subDir.Length ; i++)
		//    {
		//        string[] fileNames = Directory.GetFiles(subDir[i]);
		//        for (int j = 0 ; j < fileNames.Length ; j++)
		//        {
		//            if (fileNames[j].ToLower(m_culture).EndsWith(".xml"))
		//            {
		//                ProcessFile(fileNames[j]);
		//            }
		//        }
		//    }
		//}

		private void ProcessModifiedFiles()
		{
			try
			{
				//Loop through file list
                for (int i = m_filePaths.Count; i >= 0;  i--)  
				{
					//If changed
					if (m_filePaths.Values[i])
					{
						// Reset modified flag
                        m_filePaths[m_filePaths.Keys[i]] = false;
					}
					else
					{
                        string impFile = m_filePaths.Keys[i];
                        m_filePaths.RemoveAt(i);

						ProcessFile(impFile);
					}
				}
		
				//Stop timer if no files left
				if (m_filePaths.Count == 0)
				{
					StopTimer();
				}
			}
			catch
			{
				throw;
			}
		}

		private void ProcessFile(string path)
		{
			try
			{
				// Read file
                //StreamReader stream = new StreamReader(path);

				// Raise event
                //ImportedEventArgs args = new ImportedEventArgs(m_consumer, stream);
                //OnImport(args);

				if (m_config.Delete)
				{
					// Delete File
					DeleteFile(path);
				}
			}
			catch
			{
				throw;
			}
		}

//		private bool ExecuteMoveFile(string OldFilePath, string NewFilePath)
//		{
//			string sNewPath = "";
//			bool bNewFileExists = File.Exists(NewFilePath);
//
//			try 
//			{
//				if (bNewFileExists)
//				{
//					// Remove read-only
//					if ((File.GetAttributes(NewFilePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
//					{
//						File.SetAttributes(NewFilePath, File.GetAttributes(NewFilePath) ^ FileAttributes.ReadOnly);
//					}
//					System.IO.File.Delete(NewFilePath);
//				}
//
//				sNewPath = System.IO.Path.GetDirectoryName(NewFilePath);
//				if (!System.IO.Directory.Exists(sNewPath))
//				{
//					Directory.CreateDirectory(sNewPath);
//				}
//				File.Move(OldFilePath, NewFilePath);
//				return true;
//			}
//			catch (Exception Ex)
//			{
//				throw Ex;
//			}
//
//		}
		#endregion
	}
}
