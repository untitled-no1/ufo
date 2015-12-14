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
using System.Configuration;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;
using UFO.Server.Properties;

namespace UFO.Server.Test
{
    [TestClass]
    public class ServerTests
    {
        private const string TestDummyDaoAssembly = "UFO.Server.Dal.Dummy";
        private const string TestDummyDaoNameSpace = "UFO.Server.Dal.Dummy";
        private const string TestDummyDaoClassName = "DaoProviderFactory";

        private const string TestDbDaoAssemblyName = "UFO.Server.Dal.MySql";
        private const string TestDbDaoNameSpace = "UFO.Server.Dal.MySql";
        private const string TestDbDaoClassName = "DaoProviderFactory";

        #region App Config Tests

        [TestMethod]
        public void TestAppConfigRead()
        {
            var daoProviderName = Settings.Default.DaoProviderClassName;
            Assert.AreEqual(daoProviderName, TestDummyDaoClassName);
        }

        #endregion

        #region DAO Tests

        [TestMethod]
        public void TestDaoDefaultProvider()
        {
            IDaoProviderFactory daoProviderFactory = DalProviderFactories.GetDaoFactory();
            Assert.IsNotNull(daoProviderFactory);
        }
        
        [TestMethod]
        public void TestDaoInvalidProvider()
        {
            try
            {
                DalProviderFactories.GetDaoFactory("Some.Random.InvalidProvider");
                Assert.Fail("Expected exceptions did not occur!");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is SettingsPropertyNotFoundException || exception is SettingsPropertyWrongTypeException);
            }
        }

        [TestMethod]
        public void TestDummyUserDaoFilter()
        {
            var daoProviderFactory = DalProviderFactories.GetDaoFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName);
            var userDao = daoProviderFactory.CreateUserDao();
            var result = userDao.GetAllAndFilterByEmail("marius.dinu@mail.com");
            var user = result.ResultObject;

            Assert.IsNotNull(result.ResultObject);
            Assert.IsTrue("Marius" == user?.FistName && "Dinu" == user.LastName);
        }

        #endregion

        #region Dummy Data Tests
        
        [TestMethod]
        public void TestAllGeneratedUsers()
        {
            var userDao = DalProviderFactories.GetDaoFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName).CreateUserDao();
            var users = userDao.GetAll();
            Assert.IsTrue(users.ResultObject?.Count > 100);
        }

        /// <summary>
        /// The country DAO has no implementation. This test checks if the DaoExceptionHandler attribute
        /// handles the exception properly.
        /// </summary>
        [TestMethod]
        public void TestDaoExceptionHandler()
        {
            var countryDao = DalProviderFactories.GetDaoFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName).CreateCountryDao();
            var daoResponse = countryDao.GetAll();
            Assert.IsTrue(daoResponse.ResponseStatus == DaoStatus.Failed);
        }

        #endregion



        #region Database Data Access Test

        [TestMethod]
        public void TestAllUserDbAccess()
        {
            var userDao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();
            DaoResponse<IList<User>> response = userDao.GetAll();
            Assert.IsTrue(response.ResultObject?.Count > 10);
        }

        [TestMethod]
        public void TestUpdateUserDbAccess()
        {
            var userDao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();

            DaoResponse<User> getRsp = userDao.GetAllAndFilterByEmail("marius.dinu@mymail.com");
            Assert.IsNotNull(getRsp);
            var user = getRsp.ResultObject;
            user.FistName = "Marius";

            var updateRsp = userDao.Update(user);
            Assert.IsTrue(updateRsp.ResponseStatus == DaoStatus.Successful);
        }

        [TestMethod]
        public void TestAllCategoryDbAccess()
        {
            var categoryDao = DalProviderFactories.GetDaoFactory().CreateCategoryDao();
            var categories = categoryDao.GetAll().ResultObject;
            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any());
        }

        [TestMethod]
        public void TestAllCountryDbAccess()
        {
            var countryDao = DalProviderFactories.GetDaoFactory().CreateCountryDao();
            var countries = countryDao.GetAll().ResultObject;
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Any());
        }

        [TestMethod]
        public void TestAllArtistDbAccess()
        {
            var artistDao = DalProviderFactories.GetDaoFactory().CreateArtistDao();
            var artists = artistDao.GetAll().ResultObject;
            Assert.IsNotNull(artists);
            Assert.IsTrue(artists.Any());
        }

        [TestMethod]
        public void TestAllVenueDbAccess()
        {
            var venueDao = DalProviderFactories.GetDaoFactory().CreateVenueDao();
            var venues = venueDao.GetAll().ResultObject;
            Assert.IsNotNull(venues);
            Assert.IsTrue(venues.Any());
        }

        [TestMethod]
        public void TestAllPerformancesDbAccess()
        {
            var performanceDao = DalProviderFactories.GetDaoFactory().CreatePerformanceDao();
            var performances = performanceDao.GetAll().ResultObject;
            Assert.IsNotNull(performances);
            Assert.IsTrue(performances.Any());
        }

        #endregion
    }
}
