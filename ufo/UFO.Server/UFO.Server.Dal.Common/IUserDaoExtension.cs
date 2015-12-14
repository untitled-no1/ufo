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
using System.Linq.Expressions;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public static class IUserDaoExtension
    {

        public static DaoResponse<User> SelectByEmail(this IUserDao dao, string email)
        {
            Expression<Filter<User, string>> filterExpression = (users, value) => users.Where(x => x.EMail == value);
            var values = dao.SelectWhere(filterExpression, email).ResultObject;
            return values.Any() ? DaoResponse.QuerySuccessful(values.First()) : DaoResponse.QueryEmptyResult<User>();
        }

        public static DaoResponse<IList<User>> SelectByLastName(this IUserDao dao, string name)
        {
            Expression<Filter<User, string>> filterExpression = (users, value) => users.Where(x => x.LastName == value);
            var values = dao.SelectWhere(filterExpression, name).ResultObject;
            return values.Any() ? DaoResponse.QuerySuccessful(values) : DaoResponse.QueryEmptyResult<IList<User>>();
        }

        public static DaoResponse<IList<User>> SelectByFirstName(this IUserDao dao, string name)
        {
            Expression<Filter<User, string>> filterExpression = (users, value) => users.Where(x => x.FirstName == value);
            var values = dao.SelectWhere(filterExpression, name).ResultObject;
            return values.Any() ? DaoResponse.QuerySuccessful(values) : DaoResponse.QueryEmptyResult<IList<User>>();
        }
    }
}
