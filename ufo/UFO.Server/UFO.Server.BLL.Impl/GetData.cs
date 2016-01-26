using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.BLL;
using UFO.Server.BLL.Common;
using UFO.Server.Dal;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;
// ReSharper disable All

namespace UFO.Server.BLL.Impl
{
    public class GetData : IGetData
    {
        private IUserDao userDao = DalProviderFactories.GetDaoFactory().CreateUserDao();
        private IArtistDao artistDao = DalProviderFactories.GetDaoFactory().CreateArtistDao();
        private ICategoryDao categoryDao = DalProviderFactories.GetDaoFactory().CreateCategoryDao();
        private ILocationDao locationDao = DalProviderFactories.GetDaoFactory().CreateLocationDao();
        private ICountryDao countryDao = DalProviderFactories.GetDaoFactory().CreateCountryDao();
        private IVenueDao venueDao = DalProviderFactories.GetDaoFactory().CreateVenueDao();
        private IPerformanceDao performanceDao = DalProviderFactories.GetDaoFactory().CreatePerformanceDao();
        private IAuthentification authentification;

        public GetData()
        {
            
        }

        public GetData(IAuthentification authentification)
        {
            this.authentification = authentification;
        }

        public List<User> GetAllUsers()
        {
            return userDao.SelectAll().ResultObject;
        }

        public User VerifyUser(string name, string passwordHash)
        {
            var dbUser = userDao.SelectByEmail(name).ResultObject;
            if (dbUser == null)
                return null;
            User userToLog = new User {EMail = name, UserId = dbUser.UserId, Password = passwordHash};
            var loggedIn = userDao.VerifyAdminCredentials(userToLog).ResultObject;
            if (!loggedIn)
                return null;
            return dbUser;
        }

        public Artist GetArtistByName(string name)
        {
            return artistDao.SelectByName(name).ResultObject;
        }

        public Artist GetArtistById(int id)
        {
            return artistDao.SelectById(id).ResultObject;
        }

        public List<Category> GetAllCategories()
        {
            return categoryDao.SelectAll().ResultObject;
        }

        public List<Country> GetAllCountries()
        {
            return countryDao.SelectAll().ResultObject;
        }

        public List<Artist> GetAllArtists()
        {
            return artistDao.SelectAll().ResultObject;
        }

        public List<Artist> GetArtistsPage(Page page)
        {
            return artistDao.SelectPage(page).ResultObject;
        } 

        public List<Location> GetAllLocations()
        {
            return locationDao.SelectAll().ResultObject;
        }


        public Location GetLocationByName(string name)
        {
            return locationDao.SelectByName(name).ResultObject;
        }

        public Location GetLocationById(int id)
        {
            return locationDao.SelectById(id).ResultObject;
        }

        public Venue GetVenueById(string id)
        {
            return venueDao.SelectById(id).ResultObject;
        }

        public List<Venue> GetAllVenues()
        {
            return venueDao.SelectAll().ResultObject;
        }

        public List<Venue> GetVenuesPage(Page page)
        {
            return venueDao.SelectPage(page).ResultObject;
        }

        public List<Performance> GetAllPerformances()
        {
            return performanceDao.SelectAll().ResultObject;
        }

        public List<Performance> GetPerformancePage(Page page)
        {
            return performanceDao.SelectPage(page).ResultObject;
        }

        public List<Performance> GetPerformancesPerArtist(int id)
        {
            return performanceDao.SelectByArtist(id).ResultObject;
        }

        public List<Performance> GetPerformancesPerVenue(string id)
        {
            return performanceDao.SelectByVenue(id).ResultObject;
        }

        public List<Performance> GetPerformancesPerDate(DateTime d)
        {
            return performanceDao.SelectByDate(d).ResultObject;
        }

        public Performance GetPerformancePerId(DateTime d, int artistId)
        {
            return performanceDao.SelectById(d, artistId).ResultObject;
        }
    }
}
