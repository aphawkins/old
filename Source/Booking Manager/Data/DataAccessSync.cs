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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDatabaseVersion"></param>
        /// <returns>The new database version.</returns>
        public static Version UpgradeDatabase()
        {
            Settings.DatabasePath = @".\BookMan.accdb";
            // Settings.DatabasePath = @"C:\Users\Andy\Documents\Source\Booking Manager\BookMan\Database11.accdb";

            CreateNewDatabaseFile(Settings.DatabasePath);

            Version currentDatabaseVersion = DataAccess.GetDatabaseVersion();
            Version scriptVersion = currentDatabaseVersion;

            // TODO: What if somebody else updates the database at exactly the same time?
            // The transaction will fail, but it'll still be an updated state.
            // check the version if it fails?

            using (DbConnection connection = DataConnectionFactory.GetOpenConnection())
            {
                DbTransaction transaction;

                using (transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (TextReader textStreamReader = new StreamReader(AssemblyInformation.This().GetManifestResourceStream(string.Format(CultureInfo.InvariantCulture, "{0}.Database.Script", AssemblyInformation.AssemblyName()))))
                        {
                            while (-1 != textStreamReader.Peek())
                            {
                                string sqlFile = textStreamReader.ReadLine();

                                if (sqlFile.StartsWith("#", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (scriptVersion > currentDatabaseVersion)
                                    {
                                        SetDatabaseVersion(transaction, scriptVersion);
                                        transaction.Commit();
                                        // Do each database version as a seperate transaction
                                        transaction = connection.BeginTransaction();
                                    }

                                    bool success = Version.TryParse(sqlFile.TrimStart('#'), out scriptVersion);
                                    Debug.Assert(success);
                                    Debug.Assert(scriptVersion != null);
                                }
                                else
                                {
                                    if (scriptVersion > currentDatabaseVersion)
                                    {
                                        ExecuteSqlFile(transaction, sqlFile);
                                    }
                                }
                            }
                        }

                        Debug.Assert(scriptVersion != null);

                        if (scriptVersion > currentDatabaseVersion)
                        {
                            SetDatabaseVersion(transaction, scriptVersion);
                            transaction.Commit();
                        }
                    }
                    catch (DbException)
                    {
                        transaction.Rollback();
                        throw;
                    }

                    return scriptVersion;
                }
            }
        }

        public static DataSet GetPerson(int personId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
            {
                {"Id", personId} 
            };

            return ExecuteStoredProcedure("GetPersonById", parameters);
        }
    }
}
