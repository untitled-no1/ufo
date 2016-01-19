using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UFO.Commander.Annotations;
using UFO.Commander.Util;
using UFO.Server.Domain;
// ReSharper disable All

namespace UFO.Commander.ViewModels
{
    public class LocationDataViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<LocationViewModel> Locations => DataContainer.GetLocationObservColl();
        public event PropertyChangedEventHandler PropertyChanged;

        private LocationViewModel curLocation;

        public LocationViewModel CurLocation
        {
            get { return curLocation; }
            set
            {
                curLocation = value;
                OnPropertyChanged(nameof(CurLocation));
            }
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand saveCommand;
        public ICommand SaveCommand => saveCommand ?? (saveCommand = new RelayCommand(SaveCommandExecute));
        
        private void SaveCommandExecute(object obj)
        {
            DataContainer.SaveLocationsChanged();
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(DeleteCommandExecute));

        private void DeleteCommandExecute(object obj)
        {
            Location a = Session.GetData.GetLocationByName(CurLocation.Name);
            Session.ModifyData.DeleteLocation(a);
            Console.WriteLine(a.Name + " deleted");
            DataContainer.InitLocationObservList();
        }




    }
}
