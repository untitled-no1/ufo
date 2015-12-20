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
        private static ObservableCollection<CategoryViewModel> CategoriesObs = new ObservableCollection<CategoryViewModel>();
         
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
        private static ObservableCollection<CountryViewModel> CountriesObs = new ObservableCollection<CountryViewModel>();
        public static List<Country>GetCountriesList()
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
    }
}
