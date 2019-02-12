using System;
using System.Collections;
using System.Timers;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Threading;


namespace Useful.DataServices
{
	/// <summary>
	/// Summary description for Subscription.
	/// </summary>
	internal class Subscription : WatcherBase
	{
		private SubsConfig m_config;
		private System.Timers.Timer m_timer;
		private SqlConnection m_sqlConn;
		private Hashtable m_documentIds;
		private CultureInfo m_culture = new CultureInfo("en-GB");

		#region Initialisation
		internal Subscription(SubsConfig subs)
		{
			m_config = (SubsConfig)subs;
		}

		internal override void Start()
		{
			//Debug.Print(Debug.Module.Subscription, "Started");

			//			ReadSubscriptions();

			m_documentIds = new Hashtable();

			m_timer = new System.Timers.Timer();
			m_timer.Interval = (double)m_config.TimeOut;
			m_timer.Elapsed += new System.Timers.ElapsedEventHandler(m_timer_Elapsed);
			m_timer.Enabled = true;
			//Debug.Print(Debug.Module.Subscription, "Timer - Started");
		}

		internal override IConfig Config
		{
			set 
			{
				m_config = (SubsConfig)value;
			}
		}
		#endregion

		#region Database
		private static SqlConnection GetConnection(string connectionString)
		{
			SqlConnection sqlConn = new SqlConnection(connectionString);
			try
			{
				sqlConn.Open();
				return sqlConn;
			}
			catch
			{
				sqlConn = null;
				throw;
			}
		}
		#endregion

		#region Timer
		private void m_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				//Debug.Print(Debug.Module.Subscription, "Timer - Event Raised");

				m_timer.Enabled = false;
				ReadDocumentStore();
				m_timer.Enabled = true;

			}
			catch
			{
				throw;
				//Error.Raise(Ex);
			}
		}
		#endregion

		#region Read Document Store
		private void ReadDocumentStore()
		{
			string key = null;
			string sql = @"select docs.cid, docs.document_id, docs.xml_schema_name, docs.from_external_system, subs.external_system_name, docs.document_data" +
				@" from st_ds_document_store docs left join st_ds_subscription subs" +
				@" on docs.cid = subs.cid" +
				@" and docs.xml_schema_name = subs.xml_schema_name" +
				@" and docs.from_external_system <> subs.external_system_name" +
				@" and subs.is_imported = 1" +
				@" where docs.document_id not in" +
				@" (select document_id" +
				@" from st_ds_history)" +
				@" order by docs.creation_date";

			/*
			select docs.cid, docs.document_id, docs.xml_schema_name, docs.from_external_system, subs.external_system_name, docs.document_data
			from st_ds_document_store docs left join st_ds_subscription subs 
			on docs.cid = subs.cid
			and docs.xml_schema_name = subs.xml_schema_name
			and docs.from_external_system <> subs.external_system_name
			and subs.is_imported = 1
			where docs.document_id not in
			(select document_id
			from st_ds_history)
			order by docs.creation_date
			*/

			try
			{
				m_sqlConn = GetConnection(m_config.DatabaseConn);
				SqlCommand sqlComm = new SqlCommand(sql, m_sqlConn);
				SqlDataReader sqlRead = sqlComm.ExecuteReader();

				while (sqlRead.Read())
				{

					// Need to read results into collection of subscriptions
					DocSubs docSubs;
					docSubs.Cid = sqlRead.GetInt32(0);
					docSubs.DocumentId = Convert.ToString(sqlRead.GetValue(1), m_culture);
					docSubs.SchemaName = sqlRead.GetString(2);
					docSubs.FromSystem = sqlRead.GetString(3);
					docSubs.ToSystem = sqlRead.GetString(4);
					docSubs.Xml = sqlRead.GetString(5);
					docSubs.Successful = false;	// Assume it didn't import successfully until we know that it will
					docSubs.Errors = null; // Assume no errors yet found

					key = docSubs.DocumentId + "." + docSubs.ToSystem;
					if (!m_documentIds.Contains(key))
					{
						// Import not already taking place
						m_documentIds.Add(key, key);

						ImportThread import = new ImportThread(docSubs, m_config.DatabaseConn, new ImportThreadCallback(ResultCallback));

						Thread t = new Thread(new ThreadStart(import.Start));
						t.Start();
					}
				}

			}
			catch
			{
				throw;
			}
		}

		private void ResultCallback(string documentId, string ToSystem) 
		{
			string key = documentId + "." + ToSystem;
			if (m_documentIds.ContainsKey(key))
			{
				m_documentIds.Remove(key);
			}
			if (m_documentIds.Count <= 0)
			{
				//Debug.Print(Debug.Module.Subscription, "All jobs complete");
			}
		}
		#endregion
	}


}
