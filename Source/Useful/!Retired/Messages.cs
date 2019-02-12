using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Useful
{
	/// <summary>
	/// 
	/// </summary>
	public class Messages
	{
        private Collection<Message> messages;		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="messages"></param>
		public Messages(Message[] messages)
		{
			this.messages = new Collection<Message>(messages);
		}

		/// <summary>
		/// 
		/// </summary>
		public Collection<Message> Message
		{
			get
			{
				return this.messages;
			}
		}
	}
}
