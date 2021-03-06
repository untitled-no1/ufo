﻿#region copyright
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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public static class IPerformanceDaoExtension
    {
        public static DaoResponse<Performance> SelectByDateTime(this IPerformanceDao dao, DateTime datetime)
        {
            Expression<Filter<Performance, DateTime>> filterExpression = (performances, value) => performances.Where(x => x.DateTime == value);
            var values = dao.SelectWhere(filterExpression, datetime).ResultObject;
            return values.Any() ? DaoResponse.QuerySuccessful(values.First()) : DaoResponse.QueryEmptyResult<Performance>();
        }

        public static DaoResponse<List<Performance>> SelectByArtist(this IPerformanceDao dao, int id)
        {
            Expression<Filter<Performance, int>> filterExpression = (performances, value) => performances.Where(x => x.Artist.ArtistId == value);
            var values = dao.SelectWhere(filterExpression, id).ResultObject;
            return values.Any() ? DaoResponse.QuerySuccessful(values) : DaoResponse.QueryEmptyResult<List<Performance>>();
        }

        public static DaoResponse<List<Performance>> SelectByVenue(this IPerformanceDao dao, string id)
        {
            Expression<Filter<Performance, string>> filterExpression = (performances, value) => performances.Where(x => x.Venue.VenueId == value);
            var values = dao.SelectWhere(filterExpression, id).ResultObject;
            return values.Any() ? DaoResponse.QuerySuccessful(values) : DaoResponse.QueryEmptyResult<List<Performance>>();
        }
    }


}
