using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UFO.Commander.Annotations;
using UFO.Commander.Util;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class VenueViewModel : INotifyPropertyChanged
    {
        private Venue venue;
        
        public string VenueId
        {
            get { return venue?.VenueId; }
            set
            {
                venue.VenueId = value;
                OnPropertyChanged(nameof(VenueId));
            }
        }

        public string Name
        {
            get { return venue?.Name; }
            set
            {
                venue.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int LocId
        {
            get { return venue.Location.LocationId; }
            set
            {
                venue.Location.LocationId = value;
                OnPropertyChanged(nameof(LocId));
            }
        }

        public string LocName => venue.Location.Name;


        public VenueViewModel() : this(new Venue())
        {
            
        }

        public VenueViewModel(Venue v)
        {
            venue = v;
            venue = venue ?? new Venue();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            DataContainer.AddToVenueChanged(venue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
