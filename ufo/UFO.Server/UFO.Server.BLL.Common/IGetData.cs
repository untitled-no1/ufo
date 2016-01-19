using System.Collections.Generic;
using UFO.Server.Domain;

namespace UFO.Server.BLL.Common
{
    public interface IGetData
    {
        // User
        List<User> GetAllUsers();

        // Artist
        Artist GetArtistByName(string name);
        List<Artist> GetAllArtists();

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
    }
}
