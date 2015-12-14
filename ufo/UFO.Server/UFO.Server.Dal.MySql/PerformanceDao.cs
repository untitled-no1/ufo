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
    class PerformanceDao : IPerformanceDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public PerformanceDao(ADbCommProvider dbCommProvider)
        {
            _dbCommProvider = dbCommProvider;
        }


        private Performance CreatePerformanceObject(IDataReader dataReader)
        {
            var performance = new Performance
            {
                DateTime = (DateTime)dataReader["Date"]
            };

            var artist = new Artist
            {
                ArtistId = _dbCommProvider.CastDbObject<int>(dataReader, "ArtistId"),
                Name =  _dbCommProvider.CastDbObject<string>(dataReader, "ArtistName"),
                EMail = _dbCommProvider.CastDbObject<string>(dataReader, "EMail"),
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
            performance.Artist = artist;

            if (!_dbCommProvider.IsDbNull(dataReader, "VenueId"))
            {
                var venue = new Venue
                {
                    VenueId = _dbCommProvider.CastDbObject<string>(dataReader, "VenueId"),
                    Name = _dbCommProvider.CastDbObject<string>(dataReader, "VenueName"),
                    Location = new Location
                    {
                        LocationId = _dbCommProvider.CastDbObject<int>(dataReader, "LocationId"),
                        Name = _dbCommProvider.CastDbObject<string>(dataReader, "LocationName"),
                        Latitude = _dbCommProvider.CastDbObject<decimal>(dataReader, "Latitude"),
                        Longitude = _dbCommProvider.CastDbObject<decimal>(dataReader, "Longitude")
                    }
                };
                performance.Venue = venue;
            }

            return performance;
        }

        [DaoExceptionHandler(typeof(Performance))]
        public DaoResponse<Performance> Update(Performance performance)
        {
            throw new System.NotImplementedException();
        }

        [DaoExceptionHandler(typeof(IList<Performance>))]
        public DaoResponse<IList<Performance>> GetAll()
        {
            var performances = new List<Performance>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectAllPerfomances))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    performances.Add(CreatePerformanceObject(dataReader));
                }
            }

            return DaoResponse.QuerySuccessfull<IList<Performance>>(performances);
        }

        [DaoExceptionHandler(typeof(IList<Performance>))]
        public DaoResponse<IList<Performance>> GetAllAndFilterBy<T>(T criteria, Filter<Performance, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<Performance>>(
                new List<Performance>(filter.Invoke(GetAll().ResultObject, criteria)));
        }
    }
}