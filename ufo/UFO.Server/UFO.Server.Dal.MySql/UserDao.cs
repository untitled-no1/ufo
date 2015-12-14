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
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class UserDao : IUserDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public UserDao(ADbCommProvider dbDbCommProvider)
        {
            this._dbCommProvider = dbDbCommProvider;
        }

        private User CreateUserObject(IDataReader dataReader)
        {
            var user = new User
            {
                UserId = _dbCommProvider.CastDbObject<int>(dataReader, "UserId"),
                FirstName = _dbCommProvider.CastDbObject<string>(dataReader, "FirstName"),
                LastName = _dbCommProvider.CastDbObject<string>(dataReader, "LastName"),
                EMail = _dbCommProvider.CastDbObject<string>(dataReader, "UserMail"),
                Password = _dbCommProvider.CastDbObject<string>(dataReader, "Password"),
                IsAdmin = _dbCommProvider.CastDbObject<bool>(dataReader, "IsAdmin"),
                IsArtist = _dbCommProvider.CastDbObject<bool>(dataReader, "IsArtist")
            };

            if (!_dbCommProvider.IsDbNull(dataReader, "ArtistId"))
            {
                var artist = new Artist
                {
                    ArtistId = _dbCommProvider.CastDbObject<int>(dataReader, "ArtistId"),
                    Name = _dbCommProvider.CastDbObject<string>(dataReader, "ArtistName"),
                    EMail = _dbCommProvider.CastDbObject<string>(dataReader, "ArtistMail"),
                    PromoVideo = _dbCommProvider.CastDbObject<string>(dataReader, "PromoVideo"),
                    Picture = BlobData.CreateBlobData(_dbCommProvider.CastDbObject<string>(dataReader, "Picture")),
                    Country = new Country
                    {
                        Code = _dbCommProvider.CastDbObject<string>(dataReader, "CountryCode"),
                        Name = _dbCommProvider.CastDbObject<string>(dataReader, "CountryName")
                    }
                };
                if (!_dbCommProvider.IsDbNull(dataReader, "CategoryId"))
                {
                    artist.Category = new Category
                    {
                        CategoryId = _dbCommProvider.CastDbObject<string>(dataReader, "CategoryId"),
                        Name = _dbCommProvider.CastDbObject<string>(dataReader, "CategoryName")
                    };
                }
                user.Artist = artist;
            }

            return user;
        }

        private Dictionary<string, QueryParameter> CreateUserParameter(User entity)
        {
            return new Dictionary<string, QueryParameter>
            {
                {"?UserId", new QueryParameter {ParameterValue = entity.UserId}},
                {"?FirstName", new QueryParameter {ParameterValue = entity.FirstName}},
                {"?LastName", new QueryParameter {ParameterValue = entity.LastName}},
                {"?Password", new QueryParameter {ParameterValue = entity.Password}},
                {"?IsAdmin", new QueryParameter {ParameterValue = entity.IsAdmin}},
                {"?IsArtist", new QueryParameter {ParameterValue = entity.IsArtist}},
                {"?ArtistId", new QueryParameter {ParameterValue = entity.Artist?.ArtistId}}
            };
        }

        [DaoExceptionHandler(typeof(User))]
        public DaoResponse<User> Insert(User entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.InsertUser, CreateUserParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(User))]
        public DaoResponse<User> Update(User entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.UpdateUser, CreateUserParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(User))]
        public DaoResponse<User> Delete(User entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.DeleteUser, CreateUserParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(IList<User>))]
        public DaoResponse<User> SelectById(int id)
        {
            User user = null;
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?UserId", new QueryParameter {ParameterValue = id}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectUserById, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                if (dataReader.Read())
                {
                    user = CreateUserObject(dataReader);
                }
            }
            return user != null ? DaoResponse.QuerySuccessful(user) : DaoResponse.QueryEmptyResult<User>();
        }

        [DaoExceptionHandler(typeof(bool))]
        public DaoResponse<bool> VerifyAdminCredentials(User user)
        {
            DaoResponse<bool> daoResponse = null;
            SelectById(user.UserId)
                .OnFailure(response =>
                {
                    throw response.Exception;
                })
                .OnSuccess(u =>
                {
                    if (u.Password == user.Password && u.IsAdmin)
                    {
                        daoResponse = DaoResponse.QuerySuccessful(true);
                    }
                    else
                    {
                        const string msg = "Invalid user credentials.";
                        daoResponse = DaoResponse.QueryFailed(false, msg, new InvalidCredentialException(msg));
                    }
                })
                .OnEmptyResult(() =>
                {
                    daoResponse = DaoResponse.QueryEmptyResult<bool>();
                });
            return daoResponse;
        }

        [DaoExceptionHandler(typeof(IList<User>))]
        public DaoResponse<IList<User>> SelectAll()
        {
            var users = new List<User>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectAllUsers))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    users.Add(CreateUserObject(dataReader));
                }
            }
            return users.Any() ? DaoResponse.QuerySuccessful<IList<User>>(users) : DaoResponse.QueryEmptyResult<IList<User>>();
        }

        [DaoExceptionHandler(typeof(IList<User>))]
        public DaoResponse<IList<User>> SelectWhere<T>(Expression<Filter<User, T>> filterExpression, T criteria)
        {
            return DaoResponse.QuerySuccessful<IList<User>>(
                new List<User>(filterExpression.Compile()(SelectAll().ResultObject, criteria)));
        }
    }
}
