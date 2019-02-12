using System;
using System.Data;
using System.Configuration;

namespace Useful
{
	/// <summary>
	/// A Message Log Message.
	/// </summary>
	public class Message
	{
		private string from;
		private DateTime date;
		private string text;

		/// <summary>
		/// Who sent the message.
		/// </summary>
		public string From
		{
			get
			{
				return this.from;
			}
			set
			{
				this.from = value;
			}
		}

		/// <summary>
		/// The date the message was sent.
		/// </summary>
		public DateTime Date
		{
			get
			{
				return this.date;
			}
			set
			{
				this.date = value;
			}
		}


		/// <summary>
		/// The message body.
		/// </summary>
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
			}
		}
	}
}
