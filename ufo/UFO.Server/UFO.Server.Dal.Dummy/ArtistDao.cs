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
using System.Linq.Expressions;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
{
    class ArtistDao : IArtistDao
    {
        public DaoResponse<Artist> Insert(Artist artist)
        {
            throw new System.NotImplementedException();
        }
        
        public DaoResponse<Artist> Update(Artist artist)
        {
            throw new System.NotImplementedException();
        }
        
        public DaoResponse<Artist> Delete(Artist artist)
        {
            throw new System.NotImplementedException();
        }
        
        public DaoResponse<IList<Artist>> SelectAll()
        {
            throw new System.NotImplementedException();
        }
        
        public DaoResponse<IList<Artist>> SelectWhere<T>(Expression<Filter<Artist, T>> filterExpression, T criteria)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<Artist> SelectById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
