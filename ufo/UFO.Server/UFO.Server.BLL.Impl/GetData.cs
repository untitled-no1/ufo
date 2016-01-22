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

        public GetData(IAuthentification authentification)
        {
            this.authentification = authentification;
        }

        public List<User> GetAllUsers()
        {
            if (!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return userDao.SelectAll().ResultObject;
        }

        public Artist GetArtistByName(string name)
        {
            if (!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return artistDao.SelectByName(name).ResultObject;
        }

        public List<Category> GetAllCategories()
        {
            if(!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return categoryDao.SelectAll().ResultObject;
        }

        public List<Country> GetAllCountries()
        {
            if (!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return countryDao.SelectAll().ResultObject;
        }

        public List<Artist> GetAllArtists()
        {
            if (!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return artistDao.SelectAll().ResultObject;
        }

        public List<Artist> GetArtistsPage(Page page)
        {
            if(!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return artistDao.SelectPage(page).ResultObject;
        } 

        public List<Location> GetAllLocations()
        {
            if(!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return locationDao.SelectAll().ResultObject;
        }


        public Location GetLocationByName(string name)
        {
            if (!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return locationDao.SelectByName(name).ResultObject;
        }

        public Location GetLocationById(int id)
        {
            if (!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return locationDao.SelectById(id).ResultObject;
        }

        public Venue GetVenueById(string id)
        {
            if(!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return venueDao.SelectById(id).ResultObject;
        }

        public List<Venue> GetAllVenues()
        {
            if(!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return venueDao.SelectAll().ResultObject;
        }

        public List<Performance> GetAllPerformances()
        {
            if (!authentification.IsLoggedIn())
                throw new AuthenticationException();
            return performanceDao.SelectAll().ResultObject;
        }
    }
}
