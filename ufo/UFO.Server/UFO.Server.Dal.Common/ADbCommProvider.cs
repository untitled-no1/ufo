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
using System.Linq;

namespace UFO.Server.Dal.Common
{
    public abstract class ADbCommProvider
    {
        /// <summary>
        /// Create Database specific connection types.
        /// </summary>
        /// <param name="dbProviderName">Name of the database provider.</param>
        /// <param name="connectionString">Coonection string for the database.</param>
        /// <returns></returns>
        public abstract DbConnection CreateDbConnection(string dbProviderName = null, string connectionString = null);

        /// <summary>
        /// Database independent command creation method with generic type. Can be overridden with database specific behavior.
        /// </summary>
        /// <param name="connection">Database connection for communication.</param>
        /// <param name="queryText">Database query.</param>
        /// <param name="parameters">Query parameters pairs.</param>
        /// <returns></returns>
        public abstract DbCommand CreateDbCommand<TDbType>(DbConnection connection, string queryText, Dictionary<string, QueryParameter<TDbType>> parameters = null);

        /// <summary>
        /// Database independet command creation method without generic type. Can be overridden with database specific behavior.
        /// </summary>
        /// <param name="connection">Database connection for communication.</param>
        /// <param name="queryText">Database query.</param>
        /// <param name="parameters">Query parameters pairs without typed QueryParameter.</param>
        /// <returns></returns>
        public virtual DbCommand CreateDbCommand(DbConnection connection, string queryText, Dictionary<string, QueryParameter> parameters = null)
        {
            Dictionary<string, QueryParameter<object>> nonGenericParameters = null;
            if (parameters != null)
            {
                nonGenericParameters = new Dictionary<string, QueryParameter<object>>();
                foreach (var parameter in parameters)
                {
                    nonGenericParameters[parameter.Key] = new QueryParameter<object> {ParameterValue = parameter.Value.ParameterValue};
                }
            }
            return CreateDbCommand(connection, queryText, nonGenericParameters);
        }

        /// <summary>
        /// Cast a read object from the IDataReader to the target generic type.
        /// </summary>
        /// <typeparam name="T">Type used for the cast.</typeparam>
        /// <param name="reader">Database reader.</param>
        /// <param name="column">Name of the column to be read by the IDataReader.</param>
        /// <returns>Cast type or default value of T.</returns>
        public virtual T CastDbObject<T>(IDataReader reader, string column)
        {
            return !Convert.IsDBNull(reader[column]) ? (T) reader[column] : default(T);
        }

        /// <summary>
        /// Verify if the IDataReader did not contain an specified column. Null value checks.
        /// </summary>
        /// <param name="reader">Database reader.</param>
        /// <param name="column">Name of the column to be read by the IDataReader.</param>
        /// <returns>True if an object is availabe or false if the database entry is null.</returns>
        public virtual bool IsDbNull(IDataReader reader, string column)
        {
            return reader[column] is DBNull;
        }

        /// <summary>
        /// Reader implementation for the specified database.
        /// </summary>
        /// <param name="command">Command to be executed.</param>
        /// <returns>Database reader.</returns>
        public abstract IDataReader ExecuteReader(DbCommand command);

        /// <summary>
        /// Non-Query execution implementation for the specified database.
        /// </summary>
        /// <param name="command">Command to be executed.</param>
        /// <returns>The number of rows affected.</returns>
        public abstract int ExecuteNonQuery(DbCommand command);
    }
}
