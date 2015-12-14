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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Dal.MySql
{
    public static class SqlQueries
    {
        // User
        public const string SelectAllUsers = @"SELECT *
                                                 FROM userview";

        public const string SelectUserById = @"SELECT *
                                                 FROM userview
                                                WHERE UserId=?UserId";

        public const string DeleteUser = @"DELETE FROM user
                                                 WHERE UserId=?UserId";

        public const string UpdateUser = @"UPDATE user 
                                              SET FirstName=?FirstName, LastName=?LastName, Password=?Password, IsAdmin=?IsAdmin, IsArtist=?IsArtist, ArtistId=?ArtistId 
                                            WHERE UserId=?UserId";

        public const string InsertUser = @"INSERT INTO user (FirstName, LastName, Password, IsAdmin, IsArtist, ArtistId)
                                                  VALUES (?FirstName, ?LastName, ?Password, ?IsAdmin, ?IsArtist, ?ArtistId)";



        // Performance
        public const string SelectAllPerfomances = @"SELECT *
                                                       FROM performanceview";

        public const string SelectPerformanceById = @"SELECT *
                                                        FROM performanceview
                                                       WHERE Date=?Date AND ArtistId=?ArtistId";

        public const string DeletePerformance = @"DELETE FROM performance
                                                   WHERE Date=?Date AND ArtistId=?ArtistId";

        public const string UpdatePerformance = @"UPDATE performance 
                                                     SET VenueId=?VenueId
                                                   WHERE Date=?Date AND ArtistId=?ArtistId";

        public const string InsertPerformance = @"INSERT INTO performance (Date, ArtistId, VenueId)
                                                       VALUES (?Date, ?ArtistId, ?VenueId)";

        public const string SelectPerformanceBetweenHours = @"SELECT * 
                                                                FROM performance
                                                               WHERE Date BETWEEN CAST(?FromTime AS DATE) AND CAST(?ToTime AS DATE)
                                                                 AND ArtistId=?ArtistId";


        // Venue
        public const string SelectAllVenues = @"SELECT *
                                                  FROM venueview";

        public const string SelectVenueById = @"SELECT *
                                                  FROM venueview
                                                 WHERE VenueId=?VenueId";

        public const string DeleteVenue = @"DELETE FROM venue
                                                  WHERE VenueId=?VenueId";

        public const string UpdateVenue = @"UPDATE venue 
                                               SET Name=?Name, LocationId=?LocationId
                                             WHERE VenueId=?VenueId";

        public const string InsertVenue = @"INSERT INTO venue (Name, VenueId, LocationId)
                                                  VALUES (?Name, ?VenueId, ?LocationId)";



        // Artist
        public const string SelectAllArtists =  @"SELECT * 
                                                    FROM artistview";

        public const string SelectArtistById = @"SELECT * 
                                                   FROM artistview 
                                                  WHERE ArtistId=?ArtistId";

        public const string DeleteArtist = @"DELETE FROM artist
                                                   WHERE ArtistId=?ArtistId";

        public const string UpdateArtist = @"UPDATE artist 
                                                SET Name=?Name, EMail=?EMail, CategoryId=?CategoryId, CountryCode=?CountryCode, Picture=?Picture, PromoVideo=?PromoVideo 
                                              WHERE ArtistId=?ArtistId";

        public const string InsertArtist = @"INSERT INTO artist (Name, EMail, CategoryId, CountryCode, Picture, PromoVideo)
                                                  VALUES (?Name, ?EMail, ?CategoryId, ?CountryCode, ?Picture, ?PromoVideo)";



        // Country
        public const string SelectAllCountries = @"SELECT * 
                                                     FROM country";

        public const string SelectCountryById = @"SELECT * 
                                                    FROM country 
                                                   WHERE Code=?Code";

        public const string UpdateCountry = @"UPDATE country 
                                                 SET Name=?Name 
                                               WHERE Code=?Code";

        public const string DeleteCountry = @"DELETE FROM country
                                                    WHERE Code=?Code";

        public const string InsertCountry = @"INSERT INTO country (Code, Name)
                                                   VALUES (?Code, ?Name)";


        // Category
        public const string SelectAllCategories = @"SELECT * 
                                                      FROM category";

        public const string SelectCategoryById = @"SELECT * 
                                                     FROM category 
                                                    WHERE CategoryId=?CategoryId";

        public const string UpdateCategory = @"UPDATE category 
                                                  SET Name=?Name 
                                                WHERE CategoryId=?CategoryId";

        public const string DeleteCategory = @"DELETE FROM category
                                                     WHERE CategoryId=?CategoryId";

        public const string InsertCategory = @"INSERT INTO category (CategoryId, Name)
                                                    VALUES (?CategoryId, ?Name)";

        
        // Location
        public const string SelectAllLocations = @"SELECT * 
                                                      FROM location";

        public const string SelectLocationById = @"SELECT * 
                                                     FROM location 
                                                    WHERE LocationId=?LocationId";

        public const string UpdateLocation = @"UPDATE location 
                                                  SET Name=?Name, Longitude=?Longitude, Latitude=?Latitude
                                                WHERE Location=?LocationId";

        public const string DeleteLocation = @"DELETE FROM location
                                                     WHERE LocationId=?LocationId";

        public const string InsertLocation = @"INSERT INTO location (LocationId, Longitude, Latitude, Name)
                                                    VALUES (?LocationId, ?Longitude, ?Latitude, ?Name)";

    }
}
