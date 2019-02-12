using System;
using System.Messaging;
using System.IO;

namespace Useful.DataServices
{
	internal class QueueWatcher : WatcherBase
	{
        //string m_consumer;
		UsefulConfigConsumerDataServiceQueue m_config;
		MessageQueue m_MQ;

		#region initialise
		internal QueueWatcher(string consumer, UsefulConfigConsumerDataServiceQueue queues)
		{
            //m_consumer = consumer;
			m_config = queues;
		}
		
		internal override void Start()
		{
			//Debug.Print(Debug.Module.QueueWatcher, "Started");
		
			// Set up event handling queue

			m_MQ = new MessageQueue(m_config.Inbox);
//			m_MQ.Formatter = new ActiveXMessageFormatter();
			m_MQ.Formatter = new XmlMessageFormatter(new string[]{"System.String,mscorlib"});

            //m_MQ.ReceiveCompleted += new ReceiveCompletedEventHandler(this.m_watcher_ReceiveCompleted);

			// Start recieving
			m_MQ.BeginReceive();
		}


		internal UsefulConfigConsumerDataServiceQueue Config
		{
			set 
			{
				m_config = value;
			}
		}

		#endregion

		#region Queue Events
        //private void m_watcher_ReceiveCompleted(Object source, ReceiveCompletedEventArgs e)
        //{
        //    try
        //    {
        //        Message m = e.Message;
        //        StringReader stream = new StringReader((string)m.Body);

        //        //Debug.Print(Debug.Module.QueueWatcher, "Message received " + m.Label);

        //        //ImportedEventArgs args = new ImportedEventArgs(m_consumer, stream);
        //        //OnImport(args);

        //        // Reset the recieve
        //        m_MQ.BeginReceive();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
		#endregion
	}
}
