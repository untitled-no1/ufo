using System;
using System.Collections.Generic;
using UFO.Server.Domain;

namespace UFO.Server.BLL.Common
{
    public interface IGetData
    {
        // User
        List<User> GetAllUsers();
        User VerifyUser(string name, string passwordHash);

        // Artist
        Artist GetArtistById(int id);
        Artist GetArtistByName(string name);
        List<Artist> GetAllArtists();
        List<Artist> GetArtistsPage(Page page);

        // Category
        List<Category> GetAllCategories();


        // Country
        List<Country> GetAllCountries();

        //Location
        List<Location> GetAllLocations();
        Location GetLocationByName(string name);
        Location GetLocationById(int id);

        // Venue
        Venue GetVenueById(string id);
        List<Venue> GetAllVenues();
        List<Venue> GetVenuesPage(Page page);

        // Performance
        List<Performance> GetAllPerformances();
        List<Performance> GetPerformancePage(Page page);
        List<Performance> GetPerformancesPerArtist(int id);
        List<Performance> GetPerformancesPerVenue(string id);
        List<Performance> GetPerformancesPerDate(DateTime d);
        Performance GetPerformancePerId(DateTime d, int artistId);
    }
}
