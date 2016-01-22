using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UFO.Commander.Annotations;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class PerformanceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private Performance performance;

        public string LocationName
        {
            get { return performance?.Venue.Location.Name; }

        }

        public string VenueId
        {
            get { return performance?.Venue.VenueId; }

        }

        public string VenueName
        {
            get { return performance?.Venue.Name; }

        }

        public string ArtistName
        {
            get { return performance?.Artist.Name; }

        }

        public string ArtistCategory
        {
            get { return performance?.Artist.Category.Name; }

        }

        public string ArtistCountry
        {
            get { return performance?.Artist.Country.Code; }

        }

        public string DateString
        {
            get { return performance?.DateTime.Date.ToString("yyyy-MM-dd"); }
        }

        public DateTime DateTime
        {
            get { return performance.DateTime; }
        }

        public int Hour
        {
            get { return performance.DateTime.Hour; }
        }


        public PerformanceViewModel(Performance p)
        {
            performance = p;
        }

        public PerformanceViewModel()
        {
            performance = new Performance();
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
