using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Model;
using UFO.Commander.Annotations;
using UFO.Commander.Util;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class AgendaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Location location;
        private Venue venue;
        private DateTime date;
        private List<ArtistViewModel> artists; 

        public string LocationName => location?.Name;

        public int LocationId
        {
            get { return location.LocationId; }
            set
            {
                var loc = Session.GetData.GetLocationById(value);
                if (loc != null)
                    location = loc;
                OnPropertyChanged(nameof(LocationId));
            }
        }

        public string VenueName => venue?.Name;

        public string VenueId
        {
            get { return venue?.VenueId; }
            set
            {
                var ven = Session.GetData.GetVenueById(value);
                if (ven != null)
                    venue = ven;
                OnPropertyChanged(nameof(VenueId));
            }
        }


        public ArtistViewModel Artist14 => artists[0];

        public ArtistViewModel Artist15 => artists[1];

        public ArtistViewModel Artist16 => artists[2];

        public ArtistViewModel Artist17 => artists[3];

        public ArtistViewModel Artist18 => artists[4];

        public ArtistViewModel Artist19 => artists[5];

        public ArtistViewModel Artist20 => artists[6];

        public ArtistViewModel Artist21 => artists[7];

        public ArtistViewModel Artist22 => artists[8];

        public AgendaViewModel(Performance performance)
        {
            location = performance.Venue.Location;
            venue = performance.Venue;
            date = new DateTime(performance.DateTime.Year, performance.DateTime.Month, performance.DateTime.Day);
            artists = new List<ArtistViewModel>(9);
            AddPerformance(performance);
        }

        public void AddPerformance(Performance p)
        {
            if (p.Artist != null)
            {
                artists[p.DateTime.Hour - 14] = new ArtistViewModel(p.Artist);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
