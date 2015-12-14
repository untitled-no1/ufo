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
        /// Database independent command creation method. Can be overridden with database specific behavior.
        /// </summary>
        /// <param name="connection">Database connection.</param>
        /// <param name="queryText">Database query.</param>
        /// <param name="parameters">Query parameters pairs.</param>
        /// <returns></returns>
        public abstract DbCommand CreateDbCommand<TDbType>(DbConnection connection, string queryText, Dictionary<string, QueryParameter<TDbType>> parameters = null);

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

        public virtual T CastDbObject<T>(IDataReader reader, string column)
        {
            return !Convert.IsDBNull(reader[column]) ? (T) reader[column] : default(T);
        }

        public virtual bool IsDbNull(IDataReader reader, string column)
        {
            return reader[column] is DBNull;
        }

        public abstract IDataReader ExecuteReader(DbCommand command);

        public abstract int ExecuteNonQuery(DbCommand command);
    }
}
