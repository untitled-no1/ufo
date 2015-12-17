using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFO.Server.BLL;
using UFO.Server.BLL.Common;
using UFO.Server.BLL.Impl;
using UFO.Server.Dal;
using UFO.Server.Domain;

namespace UFO.Server.Test
{
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void TestAuthentification()
        {
            User u = DalProviderFactories.GetDaoFactory().CreateUserDao().SelectById(0).ResultObject;
            IAuthentification a = new Authentification(u);
            Assert.IsTrue(a.IsLoggedIn());
        }

        [TestMethod]
        public void TestAuthentificationFail()
        {
            User u = DalProviderFactories.GetDaoFactory().CreateUserDao().SelectById(0).ResultObject;
            u.Password = "falsepassword";
            try
            {
                IAuthentification a = new Authentification(u);
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestAuthentificationNull()
        {
            try
            {
                IAuthentification a = new Authentification(null);
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestAuthentificationLogout()
        {
            User u = DalProviderFactories.GetDaoFactory().CreateUserDao().SelectById(0).ResultObject;
            IAuthentification a = new Authentification(u);
            a.Logout();
            Assert.IsFalse(a.IsLoggedIn());
        }

        [TestMethod]
        public void TestBusinessLayerFactoryGetAllArtists()
        {
            User u = DalProviderFactories.GetDaoFactory().CreateUserDao().SelectById(0).ResultObject;
            IAuthentification a = new Authentification(u);
            var artists = BusinessLayerFactory.CreateGetDataInstance(a).GetAllArtists();
            Assert.IsTrue(artists.Count > 100);
        }

        [TestMethod]
        public void TestBusinessLayerFactoryGetAllUsers()
        {
            User u = DalProviderFactories.GetDaoFactory().CreateUserDao().SelectById(0).ResultObject;
            IAuthentification a = new Authentification(u);
            var users = BusinessLayerFactory.CreateGetDataInstance(a).GetAllUsers();
            Assert.IsTrue(users.Count > 10000);
        }
    }
}
