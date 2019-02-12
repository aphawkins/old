using System;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;

namespace Useful.DataServices
{
	internal delegate void ImportThreadCallback(string documentId, string ToSystem);

	/// <summary>
	/// ThreadWithState
	/// </summary>
	internal class ImportThread
	{	
		// Delegate
		ImportThreadCallback callback;
		DocSubs m_docSubs;
		string m_connString;
		CultureInfo m_culture = new CultureInfo("en-GB");

		internal ImportThread(DocSubs docSubs, string connString, ImportThreadCallback callbackDelegate)
		{
			m_docSubs = docSubs;
			m_connString = connString;
			callback = callbackDelegate;
		}

		internal void Start()
		{
			try
			{
				//Debug.Print(Debug.Module.Subscription, "Importing: CID " + m_docSubs.Cid.ToString(m_culture) + ": SCHEMA " + m_docSubs.SchemaName + ": INTO " + m_docSubs.ToSystem);

//				Random rnd = new Random();
//
//				//Thread.Sleep(rnd.Next(20, 120) * 1000);
//
//				IImport importer = null;
//
//				// Send XML to system import
//				switch (m_docSubs.ToSystem)
//				{
//					case "PSe":
//					{
//						importer = new PSeImporter();
//						break;
//					}
//
//					case "FlexBens":
//					{
//						importer = new Useful.DataServices.EnterpriseNet.Import();
//						break;
//
////						throw (new Exception("FlexBens Importer not found!"));
//					}
//
//					case "UniConnect":
//					{
//						throw (new Exception("UniConnect Importer not found!"));
//						//break;
//					}
//
//				}
//
//				m_docSubs.Successful = importer.ImportXml(m_docSubs.Cid, m_docSubs.Xml);
//
//				Debug.Print(Debug.Module.Subscription, "CID " + m_docSubs.Cid.ToString() + ": SCHEMA " + m_docSubs.SchemaName + ": INTO " + m_docSubs.ToSystem + ": SUCCESS " + m_docSubs.Successful.ToString());
//
//			
//				// Import sucessful?
//				if (!m_docSubs.Successful)
//				{
//					m_docSubs.Errors = importer.Errors;
//					for (int i = 0 ; i < m_docSubs.Errors.Length ; i++)
//					{
//						Debug.Print(Debug.Module.Subscription, "Error " + i.ToString() + ": " + m_docSubs.Errors[i]);
//					}
//				}
			}
			catch
			{
				//Error.Raise(Ex);
				throw;
			}

			finally
			{
				// Update document history
				//UpdateHistory();

				if (callback != null)
				{
					callback(m_docSubs.DocumentId, m_docSubs.ToSystem);
				}
			}
		}

		
		//private void UpdateHistory()
		//{
		//    try
		//    {
		//        SqlConnection sqlConn = null;

		//        int successful = 0;
		//        if (m_docSubs.Successful)
		//        {
		//            successful = 1;
		//        }

		//        string sql = "insert into ST_DS_HISTORY ( CID, LC, DATE_OF_PROCESS, FROM_EXTERNAL_SYSTEM_NAME, TO_EXTERNAL_SYSTEM_NAME, XML_SCHEMA_NAME, IS_SUCCESSFUL, DOCUMENT_ID )" +
		//            @" VALUES ( " +
		//            m_docSubs.Cid + ", " +
		//            "0, '" + 
		//            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
		//            m_docSubs.FromSystem + "', '" +
		//            m_docSubs.ToSystem + "', '" +
		//            m_docSubs.SchemaName + "', " +
		//            successful + ", " +
		//            "'{" + m_docSubs.DocumentId + "}' )";


		//        sqlConn = GetConnection(m_connString);
		//        SqlCommand sqlComm = new SqlCommand(sql, sqlConn);

		//        int rows = sqlComm.ExecuteNonQuery();
		//    }
		//    catch
		//    {
		//        throw;
		//    }
		//}


		//private SqlConnection GetConnection(string connectionString)
		//{
		//    SqlConnection sqlConn = null;
		//    try
		//    {
		//        sqlConn = new SqlConnection(connectionString);
		//        sqlConn.Open();
		//        return sqlConn;
		//    }
		//    catch
		//    {
		//        sqlConn = null;
		//        throw;
		//    }
		//}

	}
}
