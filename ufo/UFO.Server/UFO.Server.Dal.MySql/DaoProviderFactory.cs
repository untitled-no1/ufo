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
using UFO.Server.Dal.Common;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

namespace UFO.Server.Dal.MySql
{
    class DaoProviderFactory : IDaoProviderFactory
    {
        private readonly ADbCommProvider _dbCommProvider;

        [Log]
        public DaoProviderFactory()
        {
            _dbCommProvider = new DbCommProvider();
        }

        public IArtistDao CreateArtistDao()
        {
            return new ArtistDao(_dbCommProvider);
        }

        public IPerformanceDao CreatePerformanceDao()
        {
            return new PerformanceDao(_dbCommProvider);
        }

        public IUserDao CreateUserDao()
        {
            return new UserDao(_dbCommProvider);
        }

        public IVenueDao CreateVenueDao()
        {
            return new VenueDao(_dbCommProvider);
        }

        public ICategoryDao CreateCategoryDao()
        {
            return new CategoryDao(_dbCommProvider);
        }

        public ICountryDao CreateCountryDao()
        {
            return new CountryDao(_dbCommProvider);
        }
    }
}
