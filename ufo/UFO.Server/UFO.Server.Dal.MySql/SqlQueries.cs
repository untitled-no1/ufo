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

        public const string UpdateUser = @"UPDATE user 
                                              SET FirstName=?FirstName, LastName=?LastName, Password=?Password, IsAdmin=?IsAdmin, IsArtist=?IsArtist, ArtistId=?ArtistId 
                                            WHERE UserId=?UserId";

        // Performance
        public const string SelectAllPerfomances = @"SELECT *
                                                       FROM performanceview";

        // Venue
        public const string SelectAllVenues = @"SELECT *
                                                  FROM venueview";

        // Artist
        public const string SelectArtistById = @"SELECT * 
                                                   FROM artist 
                                                  WHERE ArtistId=?ArtistId";

        public const string SelectAllArtists =  @"SELECT * 
                                                    FROM artistview";
        
        // Country
        public const string SelectAllCountries = @"SELECT * 
                                                     FROM country";

        public const string SelectCountryById = @"SELECT * 
                                                    FROM country 
                                                   WHERE Code=?Code";

        // Category
        public const string SelectAllCategories = @"SELECT * 
                                                      FROM category";

        public const string SelectCategoryById = @"SELECT * 
                                                     FROM category 
                                                    WHERE CategoryId=?CategoryId";

    }
}
