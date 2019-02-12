using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Useful.DataServices
{
	class DataStore
	{
		public event EventHandler<DataStoreEventArgs> NewData;
		//public event EventHandler<DataStoreEventArgs> ProcessSuccess;
		//public event EventHandler<DataStoreEventArgs> ProcessFailed;
		//public event EventHandler<DataStoreEventArgs> ProcessedData;

		System.Collections.Generic.Dictionary<int, string> m_store;
		int m_dataId;
		
		public DataStore()
		{
			m_store = new System.Collections.Generic.Dictionary<int, string>();
		}
		
		/// <summary>
		/// Adds an item to the data store.
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="consumer"></param>
		public void AddItem(TextReader stream, string consumer)
		{
			m_dataId++;
			string str = stream.ReadToEnd();
			stream.Close();

			// Add item to data store.
			m_store.Add(m_dataId, str);

			OnNewData(new DataStoreEventArgs(consumer, m_dataId));
		}

		private void OnNewData(DataStoreEventArgs e)
		{
			if (NewData != null)
			{
				// Invokes the delegates. 
				NewData(this, e);
			}
		}

		//private void OnProcessSuccess(DataStoreEventArgs e)
		//{
		//    if (ProcessSuccess != null)
		//    {
		//        // Invokes the delegates. 
		//        ProcessSuccess(this, e);
		//    }
		//}

		//private void OnProcessFailed(DataStoreEventArgs e)
		//{
		//    if (ProcessFailed != null)
		//    {
		//        // Invokes the delegates. 
		//        ProcessFailed(this, e);
		//    }
		//}

		//private void OnProcessedData(DataStoreEventArgs e)
		//{
		//    if (ProcessedData != null)
		//    {
		//        // Invokes the delegates. 
		//        ProcessedData(this, e);
		//    }
		//}


		//private void SaveXmlToDocStore(string xml, string validationError)
		//{
		//    string sourceSystem = "";
		//    string schemaName = "";
		//    string creationDate = "";
		//    string cid = "";

		//    XPathDocument xpServiceConfig = new XPathDocument(new StringReader(xml));
		//    XPathNavigator xpNav = xpServiceConfig.CreateNavigator();
		//    XPathNodeIterator xpNodeIter = xpNav.Select("*/Header/CID");
		//    if (xpNodeIter.MoveNext())
		//    {
		//        cid = xpNodeIter.Current.Value;
		//    }
		//    xpNodeIter = xpNav.Select("*/Header/SourceSystemID");
		//    if (xpNodeIter.MoveNext())
		//    {
		//        sourceSystem = xpNodeIter.Current.Value;
		//    }
		//    xpNodeIter = xpNav.Select("*/Header/SchemaName");
		//    if (xpNodeIter.MoveNext())
		//    {
		//        schemaName = xpNodeIter.Current.Value;
		//    }
		//    xpNodeIter = xpNav.Select("*/Header/CreationDate");
		//    if (xpNodeIter.MoveNext())
		//    {
		//        creationDate = xpNodeIter.Current.Value;
		//    }
		//    if (creationDate.Length > 19)
		//    {
		//        creationDate = creationDate.Substring(0,19);
		//    }

		//    string InsertSql = "";

		//    if (validationError.Length != 0)
		//    {
		//        Debug.Print(Debug.Module.DataService, validationError);
		//        // Errors - invalid
		//        InsertSql = "insert into st_ds_invalid_document_store (CID,LC,REASON,XML_SCHEMA_NAME,FROM_EXTERNAL_SYSTEM,CREATION_DATE,DOCUMENT_DATA) VALUES" +
		//            "(" + cid + ",0,'" + validationError + "','" + schemaName.TrimEnd() + "','" +
		//            sourceSystem.TrimEnd() + "','" + creationDate + "','" + xml.TrimEnd() + "')";
		//    }
		//    else
		//    {
		//        Debug.Print(Debug.Module.DataService, "Schema valid for " + schemaName);
		//        // No errors - valid
		//        InsertSql = "insert into st_ds_document_store (CID,LC,XML_SCHEMA_NAME,FROM_EXTERNAL_SYSTEM,CREATION_DATE,DOCUMENT_DATA) VALUES" +
		//            "(" + cid + ",0,'" + schemaName.TrimEnd() + "','" +
		//            sourceSystem.TrimEnd() + "','" + creationDate + "','" + xml.TrimEnd() + "')";
		//    }

		//    SqlConnection sqlConn = GetConnection(m_DSConfig.DatabaseConn);
		//    SqlCommand sqlCmd = new SqlCommand(InsertSql, sqlConn);

		//    try
		//    {
		//        sqlCmd.ExecuteNonQuery();
		//    }
		//    catch (Exception Ex)
		//    {
		//        throw new DataServiceException("Error saving XML to store. \n" + xml, Ex);
		//    }
		//    catch
		//    {
		//        throw new DataServiceException("Error saving XML to store. \n" + xml);
		//    }

		//}

		//private bool ValidateXml(string xml, out string error)
		//{
		//    XmlTextReader xRead = new XmlTextReader(new StringReader(xml));

		//    XPathDocument xpServiceConfig = new XPathDocument(xRead);
		//    XPathNavigator xpNav = xpServiceConfig.CreateNavigator();
		//    XPathNodeIterator xpNodeIter = xpNav.Select("*/Header/SchemaName");
		//    string schemaName = "";
		//    if (xpNodeIter.MoveNext())
		//    {
		//        schemaName = xpNodeIter.Current.Value;
		//    }

		//    string xsdPath = Path.Combine(m_configWatch.Config.SchemaPath, schemaName + ".xsd");
		//    if (!File.Exists(xsdPath))
		//    {
		//        error = (schemaName + ".xsd not in schema directory.");
		//    }

		//    //Set the schema
		//    XmlSchemaSet schemaSet = new XmlSchemaSet();
		//    schemaSet.Add(null, xsdPath);

		//    error = ("Failed schema validation for " + schemaName);

		//    // Validate the XML
		//    return Useful.Xml.IsValidXml(xml, schemaSet);
		//}

		#region Database
		//private static SqlConnection GetConnection(string connectionString)
		//{
		//    SqlConnection sqlConn = new SqlConnection(connectionString);
		//    try
		//    {
		//        sqlConn.Open();
		//        return sqlConn;
		//    }
		//    catch
		//    {
		//        sqlConn = null;
		//        throw;
		//    }
		//}
		#endregion
	}
}
