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
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using MySql.Data.MySqlClient;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class CountryDao : ICountryDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public CountryDao(ADbCommProvider dbCommProvider)
        {
            this._dbCommProvider = dbCommProvider;
        }

        private Country CreateCountryObject(IDataReader dataReader)
        {
            var country = new Country
            {
                Code = _dbCommProvider.CastDbObject<string>(dataReader, "Code"),
                Name = _dbCommProvider.CastDbObject<string>(dataReader, "Name")
            };
            return country;
        }

        private Dictionary<string, QueryParameter> CreateCountryParameter(Country entity)
        {
            return new Dictionary<string, QueryParameter>
            {
                {"?Code", new QueryParameter {ParameterValue = entity.Code}},
                {"?Name", new QueryParameter {ParameterValue = entity.Name}}
            };
        }

        [DaoExceptionHandler(typeof(Country))]
        public DaoResponse<Country> GetByCode(string code)
        {
            Country country = null;
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?Code", new QueryParameter {ParameterValue = code}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectCountryById, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                if (dataReader.Read())
                {
                    country = CreateCountryObject(dataReader);
                }
            }
            return country != null ? DaoResponse.QuerySuccessful(country) : DaoResponse.QueryEmptyResult<Country>();
        }

        [DaoExceptionHandler(typeof(Country))]
        public DaoResponse<Country> Insert(Country entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.InsertCountry, CreateCountryParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(Country))]
        public DaoResponse<Country> Update(Country entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.UpdateCountry, CreateCountryParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(Country))]
        public DaoResponse<Country> Delete(Country entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.DeleteCountry, CreateCountryParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(IList<Country>))]
        public DaoResponse<IList<Country>> SelectAll()
        {
            var countries = new List<Country>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand<MySqlDbType>(connection, SqlQueries.SelectAllCountries))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    countries.Add(CreateCountryObject(dataReader));
                }
            }
            return countries.Any() ? DaoResponse.QuerySuccessful<IList<Country>>(countries) : DaoResponse.QueryEmptyResult<IList<Country>>();
        }

        [DaoExceptionHandler(typeof(IList<Country>))]
        public DaoResponse<IList<Country>> SelectWhere<T>(Expression<Filter<Country, T>> filterExpression, T criteria)
        {
            return DaoResponse.QuerySuccessful<IList<Country>>(
                new List<Country>(filterExpression.Compile()(SelectAll().ResultObject, criteria)));
        }
    }
}