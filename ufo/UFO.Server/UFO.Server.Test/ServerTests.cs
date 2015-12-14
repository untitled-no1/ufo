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
using System.Security.Cryptography;
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
        // Artist, User, Venue, Category, Country, Performance => GettAlFilterby, SelectAll, Insert, Update, Delete

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

        #region DAO Settings Tests

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
            var dao = daoProviderFactory.CreateUserDao();
            var result = dao.SelectByEmail("marius.dinu@mail.com");
            var user = result.ResultObject;

            Assert.IsNotNull(result.ResultObject);
            Assert.IsTrue("Marius" == user?.FirstName && "Dinu" == user.LastName);
        }

        #endregion

        #region Dummy Data Tests
        
        [TestMethod]
        public void TestAllGeneratedUsers()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName).CreateUserDao();
            var users = dao.SelectAll();
            Assert.IsTrue(users.ResultObject?.Count > 100);
        }

        /// <summary>
        /// The country DAO has no implementation. This test checks if the DaoExceptionHandler attribute
        /// handles the exception properly.
        /// </summary>
        [TestMethod]
        public void TestDaoExceptionHandler()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName).CreateCountryDao();
            dao.SelectAll()
                .OnSuccess(() => Assert.Fail("Response should have failed due to test of Exception handling."));
        }

        #endregion

        #region Database Data Access Tests

        // User Tests

        [TestMethod]
        public void TestAllUserDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();
            DaoResponse<IList<User>> response = dao.SelectAll();
            Assert.IsTrue(response.ResultObject?.Count > 10);
        }

        [TestMethod]
        public void TestSelectByIdUserDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();
            var user = dao.SelectById(5).ResultObject;
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// User.Insert Method is not implemented!
        /// </summary>
        [TestMethod]
        public void TestInsertUserDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();

            using (var scope = new TransactionScope())
            {
                var user = new User
                {
                    FirstName = "Horst",
                    LastName = "Futtinghartsberger",
                    EMail = "horst@futti.com",
                    Password = "horsti123",
                    IsAdmin = false,
                    IsArtist = false,
                    Artist = null
                };

                dao.Insert(user)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateUserDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByEmail("marius.dinu@mymail.com");
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var user = getRsp.ResultObject;
                user.FirstName = "Test";

                dao.Update(user)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeleteUserDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectById(6);
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var user = getRsp.ResultObject;
                
                dao.Delete(user)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        // Category Tests

        [TestMethod]
        public void TestAllCategoryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory().CreateCategoryDao();
            var categories = dao.SelectAll().ResultObject;
            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any());
        }

        [TestMethod]
        public void TestSelectByIdCategoryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCategoryDao();
            var category = dao.SelectById("OT").ResultObject;
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void TestInsertCategoryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCategoryDao();
            using (var scope = new TransactionScope())
            {
                var category = new Category
                {
                    CategoryId = "KT",
                    Name = "Klassik Tanz"
                };
                dao.Insert(category)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));
                
                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeleteCategoryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCategoryDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = ICategoryDaoExtension.SelectById(dao, "OT");
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var category = getRsp.ResultObject;
                category.Name = "Test";

                dao.Delete(category)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateCategoryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCategoryDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("Tanz");
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var category = getRsp.ResultObject;
                category.Name = "Test";

                dao.Update(category)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        // Country Tests

        [TestMethod]
        public void TestAllCountryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCountryDao();
            var countries = dao.SelectAll().ResultObject;
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Any());
        }

        [TestMethod]
        public void TestSelectByIdCountryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCountryDao();
            var country = dao.SelectByCode("AT").ResultObject;
            Assert.IsNotNull(country);
        }

        [TestMethod]
        public void TestInsertCountryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCountryDao();
            using (var scope = new TransactionScope())
            {
                var country = new Country
                {
                    Code="PD",
                    Name ="Pandora"
                };
                dao.Insert(country)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeleteCountryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCountryDao();

            using (var scope = new TransactionScope())
            {
                var country = new Country
                {
                    Code = "PD",
                    Name = "Pandora"
                };
                dao.Insert(country)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                var getRsp = dao.SelectByCode("PD");
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                country = getRsp.ResultObject;

                dao.Delete(country)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateCountryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCountryDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("Oman");
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var category = getRsp.ResultObject;
                category.Name = "Test";

                dao.Update(category)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }
        

        // Artist Tests

        [TestMethod]
        public void TestAllArtistDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateArtistDao();
            var artists = dao.SelectAll().ResultObject;
            Assert.IsNotNull(artists);
            Assert.IsTrue(artists.Any());
        }

        [TestMethod]
        public void TestSelectByIdArtistDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateArtistDao();
            var value = dao.SelectById(5).ResultObject;
            Assert.IsNotNull(value);
        }

        [TestMethod]
        public void TestDeleteArtistDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateArtistDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("AC/DC");
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var artist = getRsp.ResultObject;
                artist.Name = "Test";

                dao.Delete(artist)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateArtistDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateArtistDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("AC/DC");
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var artist = getRsp.ResultObject;
                artist.Name = "Test";

                dao.Update(artist)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestInsertArtistDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateArtistDao();

            using (var scope = new TransactionScope())
            {
                var artist = new Artist
                {
                    Name = "The Cohle",
                    Category = new Category { CategoryId = "M" },
                    Country = new Country { Code = "US" },
                    EMail = "test@chole.com",
                    Picture = BlobData.CreateBlobData("/images/prev/blobs.png")
                };

                dao.Insert(artist)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        // Venue Tests
        [TestMethod]
        public void TestAllVenueDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateVenueDao();
            var venues = dao.SelectAll().ResultObject;
            Assert.IsNotNull(venues);
            Assert.IsTrue(venues.Any());
        }

        [TestMethod]
        public void TestSelectByIdVenueDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateVenueDao();
            var value = dao.SelectById("A1").ResultObject;
            Assert.IsNotNull(value);
        }

        [TestMethod]
        public void TestInsertVenueDbAccess()
        {
            var venueDao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateVenueDao();
            using (var scope = new TransactionScope())
            {
                var venue = new Venue
                {
                    VenueId = "A7",
                    Name = "Tiki Tiki",
                    Location = new Location { LocationId = 3}
                };
                venueDao.Insert(venue)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeleteVenueDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateVenueDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectById("A1");
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var venue = getRsp.ResultObject;
                venue.Name = "Test";

                dao.Delete(venue)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateVenueDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateVenueDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("Landhaus");
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var venue = getRsp.ResultObject;
                venue.Name = "Test";

                dao.Update(venue)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        // Performance Tests
        [TestMethod]
        public void TestAllPerformancesDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreatePerformanceDao();
            var performances = dao.SelectAll().ResultObject;
            Assert.IsNotNull(performances);
            Assert.IsTrue(performances.Any());
        }

        [TestMethod]
        public void TestSelectByIdPerformanceDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreatePerformanceDao();
            var performance = dao.SelectById(new DateTime(2015, 11, 15, 22, 00, 00), 64).ResultObject;
            Assert.IsNotNull(performance);
        }

        [TestMethod]
        public void TestInsertPerformanceDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreatePerformanceDao();
            using (var scope = new TransactionScope())
            {
                var performance = new Performance
                {
                    DateTime = new DateTime(2016, 7, 18, 21, 00, 00),
                    Artist = new Artist {ArtistId = 1},
                    Venue = new Venue{VenueId = "A2"}
                };
                dao.Insert(performance)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestInsertInvalidPerformanceDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreatePerformanceDao();
            using (var scope = new TransactionScope())
            {
                var performance = new Performance
                {
                    DateTime = new DateTime(2015, 11, 15, 23, 00, 00),
                    Artist = new Artist { ArtistId = 39 },
                    Venue = new Venue { VenueId = "A2" }
                };
                dao.Insert(performance)
                    .OnSuccess(response => Assert.Fail($"Insert worked although entry already exists! {response.DateTime}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeletePerformanceDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreatePerformanceDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByDateTime(new DateTime(2015, 11, 13, 20, 00, 00));
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var performance = getRsp.ResultObject;
                performance.DateTime = new DateTime(2015,11,14);

                dao.Delete(performance)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdatePerformanceDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreatePerformanceDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectById(new DateTime(2015, 11, 15, 22, 00, 00), 64);
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                var performance = getRsp.ResultObject;
                performance.Venue = new Venue {VenueId = "P5"};

                dao.Update(performance)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }


        // Country Tests

        [TestMethod]
        public void TestAllLocationDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateLocationDao();
            var locations = dao.SelectAll().ResultObject;
            Assert.IsNotNull(locations);
            Assert.IsTrue(locations.Any());
        }

        [TestMethod]
        public void TestSelectByIdLocationDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateLocationDao();
            var location = dao.SelectById(1).ResultObject;
            Assert.IsNotNull(location);
        }

        [TestMethod]
        public void TestInsertLocationDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateLocationDao();
            using (var scope = new TransactionScope())
            {
                var location = new Location
                {
                    LocationId = 10,
                    Latitude = 24.43m,
                    Longitude = 11.3m,
                    Name = "Test"
                };
                dao.Insert(location)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeleteLocationDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateLocationDao();

            using (var scope = new TransactionScope())
            {
                var location = new Location
                {
                    LocationId = 20,
                    Latitude = 24.43m,
                    Longitude = 11.3m,
                    Name = "Test"
                };
                dao.Insert(location)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                var getRsp = dao.SelectById(20);
                getRsp
                    .OnEmptyResult(() => Assert.Fail("No data found"))
                    .OnFailure(response => Assert.Fail($"Unexpected exception occurred: {response.Exception}"));
                location = getRsp.ResultObject;

                dao.Delete(location)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        #endregion

        #region Credentials Tests

        [TestMethod]
        public void TestCryptoHash()
        {
            using (var md5 = MD5.Create())
            {
                var password = "password";
                var hash = Crypto.GetMd5Hash(md5, password);
                var user = DalProviderFactories.GetDaoFactory(
                    TestDbDaoAssemblyName,
                    TestDbDaoNameSpace,
                    TestDbDaoClassName).CreateUserDao()
                    .SelectById(0)?.ResultObject;
                Assert.IsTrue(Crypto.VerifyMd5Hash(md5, password, user?.Password));
                Assert.IsTrue(hash == user?.Password);
            }
        }

        [TestMethod]
        public void TestVerifyAdminCredentials()
        {
            var password = "password";
            string hash = null;
            using (var md5 = MD5.Create())
            {
                hash = Crypto.GetMd5Hash(md5, password);
            }
            var user = new User
            {
                UserId = 0,
                Password = hash
            };
            DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao()
                .VerifyAdminCredentials(user)
                .OnFailure(response => Assert.Fail($"Exception occurred! {response.Exception}"))
                .OnEmptyResult(() => Assert.Fail("User not found!"));
        }

        #endregion
    }
}
