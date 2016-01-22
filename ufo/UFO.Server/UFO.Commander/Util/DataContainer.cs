using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Commander.ViewModels;
using UFO.Server.Domain;

namespace UFO.Commander.Util
{
    public static class DataContainer
    {
        // Categories
        private static List<Category> Categories;

        private static ObservableCollection<CategoryViewModel> CategoriesObs =
            new ObservableCollection<CategoryViewModel>();

        public static List<Category> GetCategoriesList()
        {
            if (Categories == null)
            {
                Categories = Session.GetData.GetAllCategories();
            }

            return Categories;
        }

        public static Category FindCategoryById(string id)
        {
            foreach (var c in GetCategoriesList())
            {
                if (c.CategoryId == id)
                {
                    return c;
                }
            }
            return null;
        }

        public static ObservableCollection<CategoryViewModel> GetCategoryObservColl()
        {
            if (CategoriesObs.Count == 0)
            {
                foreach (var c in GetCategoriesList())
                {
                    CategoriesObs.Add(new CategoryViewModel(c));
                }
            }

            return CategoriesObs;
        }





        // Countries
        private static List<Country> Countries;

        private static ObservableCollection<CountryViewModel> CountriesObs =
            new ObservableCollection<CountryViewModel>();

        public static List<Country> GetCountriesList()
        {
            if (Countries == null)
            {
                Countries = Session.GetData.GetAllCountries();
            }

            return Countries;
        }

        public static Country FindCountryById(string id)
        {
            foreach (var c in GetCountriesList())
            {
                if (c.Code == id)
                {
                    return c;
                }
            }
            return null;
        }

        public static ObservableCollection<CountryViewModel> GetCountryObservColl()
        {
            if (CountriesObs.Count == 0)
            {
                foreach (var c in GetCountriesList())
                {
                    CountriesObs.Add(new CountryViewModel(c));
                }
            }

            return CountriesObs;
        }



        // Artist
        private static List<Artist> ChangedArtists = new List<Artist>();

        private static ObservableCollection<ArtistViewModel> Artists { get; } = new ObservableCollection<ArtistViewModel>();

        public static void AddToArtistChanged(Artist artist)
        {
            var alreadyChangedArtist = FindArtistById(artist);
            if (alreadyChangedArtist != null)
            {
                ChangedArtists.Remove(alreadyChangedArtist);
            }
            ChangedArtists.Add(artist);
        }

        private static Artist FindArtistById(Artist artist)
        {
            foreach (var a in ChangedArtists)
            {
                if (artist.ArtistId == a.ArtistId)
                {
                    return a;
                }
            }
            return null;
        }

        public static List<Artist> GetChangedArtistList => ChangedArtists;

        public static async void SaveArtistsChanged()
        {
            var result = await Task.Run(() => Session.ModifyData.ModifyArtists(ChangedArtists));
            Console.WriteLine(ChangedArtists.Count + " Artists changed: " + result);
            ChangedArtists.Clear();
            InitArtistObservList();
        }


        public static ObservableCollection<ArtistViewModel> GetArtistObservColl()
        {
            if (Artists.Count == 0)
            {
                InitArtistObservList();
            }

            return Artists;
        }

        public static void InitArtistObservList()
        {
            Artists.Clear();
            var dbArtists = Session.GetData.GetAllArtists();
            foreach (var a in dbArtists)
            {
                Artists.Add(new ArtistViewModel(a));
            }
            Console.WriteLine("Artists Reloaded");
        }


        // Location
        private static List<Location> ChangedLocations = new List<Location>();

        private static ObservableCollection<LocationViewModel> Locations { get; } =
            new ObservableCollection<LocationViewModel>();

        public static void AddToLocationChanged(Location location)
        {
            var alreadyChangedLocation = FindLocationById(location);
            if (alreadyChangedLocation != null)
            {
                ChangedLocations.Remove(alreadyChangedLocation);
            }
            ChangedLocations.Add(location);
        }

        private static Location FindLocationById(Location location)
        {
            foreach (var l in ChangedLocations)
            {
                if (location.LocationId == l.LocationId)
                {
                    return l;
                }
            }
            return null;
        }

        public static List<Location> GetChangedLocationList => ChangedLocations;

        public static async void SaveLocationsChanged()
        {
            var result = await Task.Run(() => Session.ModifyData.ModifyLocations(ChangedLocations));
            Console.WriteLine(ChangedLocations.Count + " Locations changed: " + result);
            ChangedLocations.Clear();
            InitLocationObservList();
        }


        public static ObservableCollection<LocationViewModel> GetLocationObservColl()
        {
            if (Locations.Count == 0)
            {
                InitLocationObservList();
            }

            return Locations;
        }

        public static void InitLocationObservList()
        {
            Locations.Clear();
            var dbLocations = Session.GetData.GetAllLocations();
            foreach (var l in dbLocations)
            {
                Locations.Add(new LocationViewModel(l));
            }
            Console.WriteLine("Locations Reloaded");
        }

        // Venue
        private static List<Venue> ChangedVenues = new List<Venue>();

        private static ObservableCollection<VenueViewModel> Venues { get; } =
            new ObservableCollection<VenueViewModel>();

        public static void AddToVenueChanged(Venue venue)
        {
            var alreadyChangedVenue = FindVenueById(venue);
            if (alreadyChangedVenue != null)
            {
                ChangedVenues.Remove(alreadyChangedVenue);
            }
            ChangedVenues.Add(venue);
        }

        private static Venue FindVenueById(Venue venue)
        {
            foreach (var l in ChangedVenues)
            {
                if (venue.VenueId == l.VenueId)
                {
                    return l;
                }
            }
            return null;
        }

        public static List<Venue> GetChangedVenueList => ChangedVenues;

        public static async void SaveVenuesChanged()
        {
            var result = await Task.Run(() => Session.ModifyData.ModifyVenues(ChangedVenues));
            Console.WriteLine(ChangedVenues.Count + " Venues changed: " + result);
            ChangedVenues.Clear();
            InitVenueObservList();
        }


        public static ObservableCollection<VenueViewModel> GetVenueObservColl()
        {
            if (Venues.Count == 0)
            {
                InitVenueObservList();
            }

            return Venues;
        }

        public static void InitVenueObservList()
        {
            Venues.Clear();
            var dbVenues = Session.GetData.GetAllVenues();
            foreach (var l in dbVenues)
            {
                Venues.Add(new VenueViewModel(l));
            }
            Console.WriteLine("Venues Reloaded");
        }


        // Performance

        private static List<string> dates = new List<string>();
        private static ObservableCollection<string> Dates { get; } = new ObservableCollection<string>();

        private static List<Performance> performances = new List<Performance>();
        private static ObservableCollection<PerformanceViewModel> Performances { get; } =
            new ObservableCollection<PerformanceViewModel>();

        public static ObservableCollection<PerformanceViewModel> GetPerformanceObservColl()
        {
            if (Performances.Count == 0)
            {
                InitPerformanceObservList();
            }

            return Performances;
        }

        public static ObservableCollection<string> GetDatesObservColl()
        {
            InitPerformanceObservList();
            if (Dates.Count == 0)
            {
                Dates.Clear();
                foreach (var d in dates)
                {
                    Dates.Add(d);
                }
            }

            return Dates;
        }

        public static void InitPerformanceObservList()
        {
            Performances.Clear();
            performances = Session.GetData.GetAllPerformances();
            foreach (var a in performances)
            {
                if(!dates.Contains(a.DateTime.Date.ToString("yyyy-MM-dd")))
                    dates.Add(a.DateTime.Date.ToString("yyyy-MM-dd"));
            }
            dates.Sort((a, b) => -1 * a.CompareTo(b));

            var firstDate = dates.First();
            foreach (var p in performances)
            {
                if(p.DateTime.Date.ToString("yyyy-MM-dd") == firstDate)
                    Performances.Add(new PerformanceViewModel(p));
            }
            Console.WriteLine("Amount of dates: " + dates.Count);
            Console.WriteLine("Performances Reloaded");
        }

        public static void RefreshPerformanceObservList(string date)
        {
            Performances.Clear();
            foreach (var p in performances)
            {
                if(date == p.DateTime.Date.ToString("yyyy-MM-dd"))
                    Performances.Add(new PerformanceViewModel(p));
            }
        }
 
    }
}
