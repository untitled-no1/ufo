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
                FistName = _dbCommProvider.CastDbObject<string>(dataReader, "FirstName"),
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

        [DaoExceptionHandler(typeof(User))]
        public DaoResponse<User> Update(User user)
        {
            var paramter = new Dictionary<string, QueryParameter>
            {
                {"?UserId", new QueryParameter {ParameterValue = user.UserId}},
                {"?FirstName", new QueryParameter {ParameterValue = user.FistName}},
                {"?LastName", new QueryParameter {ParameterValue = user.LastName}},
                {"?Password", new QueryParameter {ParameterValue = user.Password}},
                {"?IsAdmin", new QueryParameter {ParameterValue = user.IsAdmin}},
                {"?IsArtist", new QueryParameter {ParameterValue = user.IsArtist}},
                {"?ArtistId", new QueryParameter {ParameterValue = user.Artist?.ArtistId}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.UpdateUser, paramter))
            {
                _dbCommProvider.ExecuteNonQuery(command);
                return DaoResponse.QuerySuccessfull(user);
            }
        }

        [DaoExceptionHandler(typeof(IList<User>))]
        public DaoResponse<IList<User>> GetAll()
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
            return DaoResponse.QuerySuccessfull<IList<User>>(users);
        }

        [DaoExceptionHandler(typeof(IList<User>))]
        public DaoResponse<IList<User>> GetAllAndFilterBy<T>(T criteria, Filter<User, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<User>>(
                new List<User>(filter.Invoke(GetAll().ResultObject, criteria)));
        }
    }
}
