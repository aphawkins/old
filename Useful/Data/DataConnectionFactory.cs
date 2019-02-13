// -----------------------------------------------------------------------
// <copyright file="DataConnectionFactory.cs" company="">
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
    using System.Diagnostics.Contracts;

    internal static class DataConnectionFactory
    {
        private static string ConnectionString = GetConnectionString();
        
        internal static DbConnection GetOpenConnection()
        {
            DbConnection connection = new OleDbConnection(ConnectionString);

            connection.Open();

            return connection;
        }

        internal static DbCommand GetCommand()
        {
            DbCommand command = new OleDbCommand();

            return command;
        }

        internal static DbParameter GetParameter(string name, object value)
        {
            DbParameter parameter = new OleDbParameter(name, value);

            return parameter;
        }

        private static string GetConnectionString()
        {
            // TODO: Update the string on settings getting changed

            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
			//hghgh
			//Contract.ass ume (!builder.IsFixedSize);
            Contract.Assert(!builder.IsReadOnly);

            builder.Add("Provider", "Microsoft.ACE.OLEDB.12.0");
            // OLD! builder.Add("Provider", "Microsoft.Jet.Oledb.4.0");
            builder.Add("Data Source", Settings.DatabasePath);
            builder.Add("Jet OLEDB:Database Password", Settings.DatabasePassword);
            // TODO: Add database security

            //builder.Add("User Id", );
            //builder.Add("Password", );

            return builder.ConnectionString;
        }
    }
}
