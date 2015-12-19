using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Commander.ViewModels;

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


        private static PerformanceViewModel performanceViewModel;
        public static PerformanceViewModel PerformanceViewModel
            => performanceViewModel ?? (performanceViewModel = new PerformanceViewModel());

        private static VenueViewModel venueViewModel;
        public static VenueViewModel VenueViewModel
            => venueViewModel ?? (venueViewModel = new VenueViewModel());

    }
}
