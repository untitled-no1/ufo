using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.BLL.Common;
using UFO.Server.Dal;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.BLL.Impl
{
    public class ModifyData : IModifyData
    {
        private IArtistDao artistDao = DalProviderFactories.GetDaoFactory().CreateArtistDao();
        private IPerformanceDao performanceDao = DalProviderFactories.GetDaoFactory().CreatePerformanceDao();
        private ILocationDao locationDao = DalProviderFactories.GetDaoFactory().CreateLocationDao();
        private IVenueDao venueDao = DalProviderFactories.GetDaoFactory().CreateVenueDao();
        private IAuthentification authentification;

        public ModifyData(IAuthentification authentification)
        {
            this.authentification = authentification;
        }

        public bool ModifyArtists(List<Artist> artists)
        {
            var result = true;
            foreach (var a in artists)
            {
                var res = ModifyArtist(a);
                if (res == false)
                {
                    result = false;
                }
            }
            return result;
        }
        public bool ModifyArtist(Artist artist)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var status = artistDao.SelectById(artist.ArtistId).ResponseStatus == DaoStatus.Successful
                ? artistDao.Update(artist).ResponseStatus
                : artistDao.Insert(artist).ResponseStatus;

            return status == DaoStatus.Successful;
        }

        public bool DeleteArtist(Artist artist)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var status = artistDao.Delete(artist).ResponseStatus;

            return status == DaoStatus.Successful;
        }


        public bool ModifyVenues(List<Venue> venues)
        {
            var result = true;
            foreach (var a in venues)
            {
                var res = ModifyVenue(a);
                if (res == false)
                {
                    result = false;
                }
            }
            return result;
        }

        public bool ModifyVenue(Venue venue)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var status = venueDao.SelectById(venue.VenueId).ResponseStatus == DaoStatus.Successful
                ? venueDao.Update(venue).ResponseStatus
                : venueDao.Insert(venue).ResponseStatus;

            return status == DaoStatus.Successful;
        }

        public bool DeleteVenue(Venue venue)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var status = venueDao.Delete(venue).ResponseStatus;

            return status == DaoStatus.Successful;
        }


        public bool ModifyLocations(List<Location> locations)
        {
            var result = true;
            foreach (var a in locations)
            {
                var res = ModifyLocation(a);
                if (res == false)
                {
                    result = false;
                }
            }
            return result;
        }

        public bool ModifyLocation(Location location)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var status = locationDao.SelectById(location.LocationId).ResponseStatus == DaoStatus.Successful
                ? locationDao.Update(location).ResponseStatus
                : locationDao.Insert(location).ResponseStatus;
            return status == DaoStatus.Successful;

        }

        public bool DeleteLocation(Location location)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var status = locationDao.Delete(location).ResponseStatus;
            return status == DaoStatus.Successful;
        }

        public bool ModifyPerformance(Performance oldPerformance, Performance newPerformance)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var tmpPerformance = performanceDao.VerifyPerformanceValue(newPerformance);
            DaoStatus result = DaoStatus.Failed;
            if (tmpPerformance == null || tmpPerformance.Artist.Equals(oldPerformance.Artist))
            {
                result = performanceDao.Delete(oldPerformance).ResponseStatus;
                if(result == DaoStatus.Successful)
                    result = performanceDao.Insert(newPerformance).ResponseStatus;
            }
            return result == DaoStatus.Successful;
        }

        public bool DeletePerformance(Performance performance)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var status = performanceDao.Delete(performance).ResponseStatus;
            return status == DaoStatus.Successful;
        }
    }
}
