#region copyright
// (C) Copyright 2015 Dinu Marius-Constantin (http://dinu.at) and others.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Contributors:
//     Dinu Marius-Constantin
//     Wurm Florian
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Transactions;
using MySql.Data.MySqlClient;
using UFO.Server.Dal.Common;
using UFO.Server.Dal.MySql.Properties;

namespace UFO.Server.Dal.MySql
{
    public class DbCommProvider : ADbCommProvider
    {
        private string DbProviderName { get; set; }
        private string ConnectionString { get; set; }

        public override DbConnection CreateDbConnection(string dbProviderName = null, string connectionString = null)
        {
            DbProviderName = dbProviderName ?? Settings.Default.DbProviderName;
            ConnectionString = connectionString ?? Settings.Default.DbConnectionString;
            return GetOpenConnection();
        }

        public override DbCommand CreateDbCommand<TDbType>(DbConnection connection, string queryText, Dictionary<string, QueryParameter<TDbType>> parameters = null)
        {
            // cast required for own MySql mannerism to use AddWithValue method
            var command = (MySqlCommand) connection.CreateCommand();
            command.Connection = (MySqlConnection)connection;
            command.CommandText = queryText;
            command.CommandType = CommandType.Text;

            if (parameters == null)
                return command;

            foreach (var param in parameters)
            {
                DefineParameter(command, param.Key, param.Value.ParameterValue);
            }
            return command;
        }

        public override IDataReader ExecuteReader(DbCommand command)
        {
            DbConnection connection = null;
            try
            {
                connection = GetOpenConnection();
                command.Connection = connection;

                // let the reader close the connection only if it is not shared
                var behavior = Transaction.Current == null ?
                    CommandBehavior.CloseConnection :
                    CommandBehavior.Default;

                return command.ExecuteReader(behavior);
            }
            catch
            {
                ReleaseConnection(connection);
                throw;
            }
        }

        public override int ExecuteNonQuery(DbCommand command)
        {
            DbConnection connection = null;
            try
            {
                connection = GetOpenConnection();
                command.Connection = connection;
                return command.ExecuteNonQuery();
            }
            finally
            {
                ReleaseConnection(connection);
            }
        }

        private void DefineParameter(MySqlCommand command, string name, object value)
        {
            command.Parameters.AddWithValue(name, value);
        }
        
        #region connection management

        [ThreadStatic]
        private static DbConnection _sharedConnection;

        private DbConnection CreateOpenConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        private DbConnection GetOpenConnection()
        {
            var currentTransaction = Transaction.Current;

            if (currentTransaction == null)
                return CreateOpenConnection();

            if (_sharedConnection != null)
                return _sharedConnection;

            _sharedConnection = CreateOpenConnection();
            currentTransaction.TransactionCompleted += (s, e) =>
            {
                _sharedConnection.Close();
                _sharedConnection = null;
            };

            return _sharedConnection;
        }

        private void ReleaseConnection(DbConnection connection)
        {
            // close connection if no transaction is active
            if (connection != null && Transaction.Current == null)
            {
                connection.Close();
            }
        }

        #endregion
    }
}
