using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using UFO.Commander.Annotations;
using UFO.Commander.Util;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class NewLocationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


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

        private decimal longitude;
        public decimal Longitude
        {
            get { return longitude;}
            set
            {
                longitude = value;
                OnPropertyChanged(nameof(Longitude));
            }
        }


        private decimal latitude;

        public decimal Latitude
        {
            get { return latitude;}
            set
            {
                latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }

        private ICommand saveLocationCommand;

        public ICommand SaveLocationCommand
            => saveLocationCommand ?? (saveLocationCommand = new RelayCommand(SaveLocationCommandExecute));

        private async void SaveLocationCommandExecute(object obj)
        {
            Location location = new Location
            {
                Name = this.name,
                Longitude = this.longitude,
                Latitude = this.latitude
            };

            var worked = await Task.Run(() => Session.ModifyData.ModifyLocation(location));
            Console.WriteLine(location.Name + "inserted: " + worked);
            Name = "";
            Longitude = 0;
            Latitude = 0;
            DataContainer.InitLocationObservList();
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}