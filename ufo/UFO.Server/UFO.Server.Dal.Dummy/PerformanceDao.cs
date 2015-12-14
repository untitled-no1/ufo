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
using System.Linq.Expressions;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
{
    class PerformanceDao : IPerformanceDao
    {
        public DaoResponse<Performance> Insert(Performance entity)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<Performance> Update(Performance entity)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<Performance> Delete(Performance entity)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<IList<Performance>> SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<IList<Performance>> SelectWhere<T>(Expression<Filter<Performance, T>> filterExpression, T criteria)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<Performance> SelectById(DateTime dateTime, int artistId)
        {
            throw new NotImplementedException();
        }
    }
}
