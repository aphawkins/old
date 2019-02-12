// -----------------------------------------------------------------------
// <copyright file="DataAccess.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace BookMan.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    using System.Data.Common;
    using System.Data;
    using System.Reflection;
    using System.IO;
    using System.Diagnostics;
    using System.Threading;
    using System.ComponentModel;
    using System.Collections.Specialized;
    using System.Globalization;

    public partial class DataAccess
    {
        public DataAccess()
        {
            InitializeAsync();
        }

        private static void CreateNewDatabaseFile(string path)
        {
            if (File.Exists(path))
            {
                // TODO: Check the database is the correct format
                return;
            }

            // TODO: Check the location is writable
            // TODO: What if the DB disappears?  File watcher?

            using (FileStream databaseTo = File.Create(path))
            {
                Debug.Assert(databaseTo != null);

                using (Stream databaseFrom = AssemblyInformation.This().GetManifestResourceStream(string.Format(CultureInfo.InvariantCulture, "{0}.BlankAccessDatabase_v11.accdb", AssemblyInformation.AssemblyName())))
                {
                    Debug.Assert(databaseFrom != null);

                    databaseFrom.CopyTo(databaseTo);
                }
            }
        }

        //private static bool TestConnection()
        //{
        //    try
        //    {
        //        using (DbConnection testConn = DataConnectionFactory.GetOpenConnection())
        //        {
        //            return true;
        //        }
        //    }
        //    catch (DbException ex)
        //    {
        //        Log.LogException(ex);
        //        return false;
        //    }
        //}

        private static void ExecuteSqlFile(DbTransaction transaction, string filename)
        {
            string sql;

            using (Stream s = AssemblyInformation.This().GetManifestResourceStream(string.Format(CultureInfo.InvariantCulture, "{0}.Script.{1}", AssemblyInformation.AssemblyName(), filename)))
            {
                Debug.Assert(s != null);

                if (s == null)
                {
                    throw new BookManException(string.Format(CultureInfo.CurrentCulture, "Database script '{0}' not found!", filename));
                }

                using (TextReader tr = new StreamReader(s))
                {
                    sql = tr.ReadToEnd();
                }
            }

            // Create the command and set its properties.
            using (DbCommand command = DataConnectionFactory.GetCommand())
            {
                command.Connection = transaction.Connection;
                command.Transaction = transaction;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                int i = command.ExecuteNonQuery();

                Debug.Assert(i != -1);
            }
        }



        private static Version GetDatabaseVersion()
        {
            if (!DoesTableExist("Versions"))
            {
                return new Version(0, 0, 0, 0);
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>() 
            { 
                { "Type", "Database" }
            };

            DataSet result = ExecuteStoredProcedure("GetVersion", parameters);

            Version version = new Version("0.0.0.0");

            if (result.Tables.Count > 0)
            {
                Version.TryParse((string)result.Tables[0].Rows[0][0], out version);
            }
            return version;
        }

        private static void SetDatabaseVersion(DbTransaction transaction, Version newVersion)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
            { 
                { "Version", newVersion.ToString(4) },
                { "Type", "Database" }
            };

            ExecuteStoredProcedure("SetVersion", parameters, transaction);

            Log.LogInfo("Set Database version to: '{0}'", newVersion.ToString());
        }

        private static DataSet ExecuteStoredProcedure(string procedureName, IEnumerable<KeyValuePair<string, object>> parameters, DbTransaction transaction)
        {
            // Create the command and set its properties.
            using (DbCommand command = DataConnectionFactory.GetCommand())
            {
                command.Connection = transaction.Connection;
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(DataConnectionFactory.GetParameter(parameter.Key, parameter.Value));
                }

                using (DbDataAdapter adapter = new OleDbDataAdapter((OleDbCommand)command))
                {
                    DataSet myDataSet = new DataSet();
                    adapter.Fill(myDataSet);

                    return myDataSet;
                }
            }
        }

        private static DataSet ExecuteStoredProcedure(string procedureName, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            using (DbConnection connection = DataConnectionFactory.GetOpenConnection())
            {
                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DataSet result = ExecuteStoredProcedure(procedureName, parameters, transaction);
                        transaction.Commit();
                        return result;
                    }
                    catch (DbException)
                    {
                        transaction.Rollback();
                    }

                    return new DataSet();
                }
            }
        }

        private static bool DoesTableExist(string tableName)
        {
            using (DbConnection connection = DataConnectionFactory.GetOpenConnection())
            {
                using (DataTable data = ((OleDbConnection)connection).GetSchema("Tables"))
                {
                    foreach (DataRow row in data.Rows)
                    {
                        foreach (DataColumn col in data.Columns)
                        {
                            if (("TABLE_NAME".Equals(col.ColumnName, StringComparison.OrdinalIgnoreCase))
                                    && (tableName.Equals((string)row[col], StringComparison.OrdinalIgnoreCase)))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
