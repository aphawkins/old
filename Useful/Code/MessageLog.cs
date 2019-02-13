using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

namespace Useful
{
	/// <summary>
	/// Logs a message.
	/// </summary>
	public static class MessageLog
	{
		static string logFilePath = Path.Combine(Path.Combine(assemblyPath, "messages"), "messages.xml");
		static SortedDictionary<DateTime, Message> messages;

		static Assembly refAssembly = Assembly.GetCallingAssembly();
		static string assemblyFullPath = refAssembly.CodeBase;
		static Uri uri = new Uri(assemblyFullPath);
		static DirectoryInfo dir = new DirectoryInfo(uri.AbsolutePath);
		static string assemblyPath = dir.Parent.Parent.FullName;

		/// <summary>
		/// Logs a message
		/// </summary>
		/// <param name="from">Who the message is from.</param>
		/// <param name="message">The message text.</param>
		public static void LogMessage(string from, string message)
		{
			LoadLogFile();

			Message msg = new Message();
			msg.From = from;
			msg.Date = DateTime.Now;
			msg.Text = message;

			messages.Add(msg.Date, msg);

			SaveLogFile();
		}

		private static void LoadLogFile()
		{
			if (messages != null)
			{
				return;
			}

			Messages msgs;

			if (!File.Exists(logFilePath))
			{
				msgs = null;
			}
			else
			{
				TextReader tr = new StreamReader(logFilePath);
				string logFile = tr.ReadToEnd();
				tr.Close();

				msgs = (Messages)XmlSerialization.Deserialize(logFile, typeof(Messages));
			}

			messages = new SortedDictionary<DateTime, Message>();
			if (msgs.Message != null)
			{
				foreach (Message message in msgs.Message)
				{
					messages.Add(message.Date, message);
				}
			}
		}

		private static void SaveLogFile()
		{
			Messages msgs = Messages;
			string s = XmlSerialization.Serialize(msgs);
			StreamWriter sw = new StreamWriter(logFilePath);
			sw.Write(s);
			sw.Close();
		}

		/// <summary>
		/// Retrieves a list of messages.
		/// </summary>
		/// <returns>A list of messages.</returns>
		public static Messages Messages
		{
			get
			{
				LoadLogFile();

				Message[] msg = new Message[messages.Values.Count];
				messages.Values.CopyTo(msg, 0);
				Messages msgs = new Messages(msg);
				return msgs;
			}
		}
	}


}
