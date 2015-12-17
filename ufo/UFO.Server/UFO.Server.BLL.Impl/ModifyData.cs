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
        private IVenueDao venueDao = DalProviderFactories.GetDaoFactory().CreateVenueDao();
        private IPerformanceDao performanceDao = DalProviderFactories.GetDaoFactory().CreatePerformanceDao();
        private IAuthentification authentification;

        public ModifyData(IAuthentification authentification)
        {
            this.authentification = authentification;
        }

        public bool ModifyArtist(Artist artist)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var status = artistDao.SelectById(artist.ArtistId) != null
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

        public bool ModifyVenue(Venue venue)
        {
            if (!authentification.IsLoggedIn())
                return false;
            var status = venueDao.SelectById(venue.VenueId) != null
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

        public bool ModifyPerformance(Performance performance)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerformance(Performance performance)
        {
            throw new NotImplementedException();
        }
    }
}
