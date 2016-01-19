using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;
using UFO.Commander.Annotations;
using UFO.Commander.Util;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class NewVenueViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string venueId;
        public string VenueId
        {
            get { return venueId; }
            set
            {
                venueId = value;
                OnPropertyChanged(nameof(VenueId));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int locationId;

        public int LocationId
        {
            get { return locationId; }
            set
            {
                locationId = value;
                OnPropertyChanged(nameof(LocationId));
            }
        }


        private ICommand saveVenueCommand;

        public ICommand SaveVenueCommand
            => saveVenueCommand ?? (saveVenueCommand = new RelayCommand(SaveVenueCommandExecute));

        private async void SaveVenueCommandExecute(Object obj)
        {
            Location loc = Session.GetData.GetLocationById(LocationId);
            if (loc != null)
            {
                Venue venue = new Venue
                {
                    Name = this.Name,
                    VenueId = this.VenueId,
                    Location = loc
                };
                var worked = await Task.Run(() => Session.ModifyData.ModifyVenue(venue));
                Console.WriteLine(venue.VenueId + " inserted");
                Name = "";
                VenueId = "";
                LocationId = 0;
                DataContainer.InitVenueObservList();
            }
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
