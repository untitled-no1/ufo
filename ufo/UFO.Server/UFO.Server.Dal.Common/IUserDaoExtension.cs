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
using System.Linq;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public static class IUserDaoExtension
    {
        public static DaoResponse<User> GetAllAndFilterByEmail(this IUserDao userDao, string email)
        {
            Filter<User, string> filter = (users, criteria) => users.Where(x => x.EMail == criteria);
            return DaoResponse.QuerySuccessfull(userDao.GetAllAndFilterBy(email, filter).ResultObject?.First());
        }

        public static DaoResponse<IList<User>> GetAllAndFilterByLastName(this IUserDao userDao, string name)
        {
            Filter<User, string> filter = (users, criteria) => users.Where(x => x.LastName == criteria);
            return userDao.GetAllAndFilterBy(name, filter);
        }

        public static DaoResponse<IList<User>> GetAllAndFilterByFirstName(this IUserDao userDao, string name)
        {
            Filter<User, string> filter = (users, criteria) => users.Where(x => x.FistName == criteria);
            return userDao.GetAllAndFilterBy(name, filter);
        }

        public static DaoResponse<User> GetAllAndFilterById(this IUserDao userDao, int id)
        {
            Filter<User, int> filter = (users, criteria) => users.Where(x => x.UserId == criteria);
            return DaoResponse.QuerySuccessfull(userDao.GetAllAndFilterBy(id, filter).ResultObject?.First());
        }
    }
}
