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
    class ArtistDao : IArtistDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public ArtistDao(ADbCommProvider dbCommProvider)
        {
            this._dbCommProvider = dbCommProvider;
        }

        private Artist CreateArtistObject(IDataReader dataReader)
        {
            var artist = new Artist
            {
                ArtistId = _dbCommProvider.CastDbObject<int>(dataReader, "ArtistId"),
                Name = _dbCommProvider.CastDbObject<string>(dataReader, "ArtistName"),
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
            return artist;
        }

        [DaoExceptionHandler(typeof(Artist))]
        public DaoResponse<Artist> Delete(Artist artist)
        {
            throw new NotImplementedException();
        }

        [DaoExceptionHandler(typeof(IList<Artist>))]
        public DaoResponse<IList<Artist>> GetAll()
        {
            var artists = new List<Artist>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectAllArtists))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    artists.Add(CreateArtistObject(dataReader));
                }
            }
                
            return DaoResponse.QuerySuccessfull<IList<Artist>>(artists);
        }

        [DaoExceptionHandler(typeof(IList<Artist>))]
        public DaoResponse<IList<Artist>> GetAllAndFilterBy<T>(T criteria, Filter<Artist, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<Artist>>(
                new List<Artist>(filter.Invoke(GetAll().ResultObject, criteria)));
        }

        [DaoExceptionHandler(typeof(Artist))]
        public DaoResponse<Artist> Insert(Artist artist)
        {
            throw new NotImplementedException();
        }

        [DaoExceptionHandler(typeof(Artist))]
        public DaoResponse<Artist> Update(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}