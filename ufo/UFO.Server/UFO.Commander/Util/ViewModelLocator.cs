using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Commander.ViewModels;
// ReSharper disable All

namespace UFO.Commander.Util
{
    public class ViewModelLocator
    {
        private static LoginViewModel loginViewModel;
        public static LoginViewModel LoginViewModel
            => loginViewModel ?? (loginViewModel = new LoginViewModel());

        private static MainViewModel mainViewModel;
        public static MainViewModel MainViewModel
            => mainViewModel ?? (mainViewModel = new MainViewModel());

        private static ArtistDataViewModel artistDataViewModel;
        public static ArtistDataViewModel ArtistDataViewModel
            => artistDataViewModel ?? (artistDataViewModel = new ArtistDataViewModel());

        private static NewArtistViewModel newArtistViewModel;
        public static NewArtistViewModel NewArtistViewModel
            => newArtistViewModel ?? (newArtistViewModel = new NewArtistViewModel());

        private static PerformanceViewModel performanceViewModel;
        public static PerformanceViewModel PerformanceViewModel
            => performanceViewModel ?? (performanceViewModel = new PerformanceViewModel());

        private static LocationDataViewModel locationDataViewModel;
        public static LocationDataViewModel LocationDataViewModel
            => locationDataViewModel ?? (locationDataViewModel = new LocationDataViewModel());

        private static NewLocationViewModel newLocationViewModel;
        public static NewLocationViewModel NewLocationViewModel
            => newLocationViewModel ?? (newLocationViewModel = new NewLocationViewModel());

        private static VenueViewModel venueViewModel;
        public static VenueViewModel VenueViewModel
            => venueViewModel ?? (venueViewModel = new VenueViewModel());

        private static VenueDataViewModel venueDataViewModel;
        public static VenueDataViewModel VenueDataViewModel
            => venueDataViewModel ?? (venueDataViewModel = new VenueDataViewModel());


        private static NewVenueViewModel newVenueViewModel;
        public static NewVenueViewModel NewVenueViewModel
            => newVenueViewModel ?? (newVenueViewModel = new NewVenueViewModel());

    }
}
