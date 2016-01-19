using System.ComponentModel;
using System.Runtime.CompilerServices;
using UFO.Commander.Annotations;
using UFO.Commander.Util;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class LocationViewModel : INotifyPropertyChanged
    {
        private Location location;

        public int Id => location.LocationId;

        public string Name
        {
            get { return location?.Name; }
            set
            {
                location.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public decimal Longitude
        {
            get { return location.Longitude; }
            set
            {
                location.Longitude = value;
                OnPropertyChanged(nameof(Longitude));
            }
        }

        public decimal Latitude
        {
            get { return location.Latitude; }
            set
            {
                location.Latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }

        public LocationViewModel() : this(new Location())
        {
            
        }

        public LocationViewModel(Location l)
        {
            location = l;
            location = location ?? new Location();

        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged( string propertyName = null)
        {
            DataContainer.AddToLocationChanged(location);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}