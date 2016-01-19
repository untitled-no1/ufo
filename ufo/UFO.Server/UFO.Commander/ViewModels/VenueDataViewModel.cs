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

namespace UFO.Commander.ViewModels
{
    public class VenueDataViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<VenueViewModel> Venues => DataContainer.GetVenueObservColl();

        private VenueViewModel curVenue;

        public VenueViewModel CurVenue
        {
            get {  return curVenue;}
            set
            {
                curVenue = value;
                OnPropertyChanged(nameof(CurVenue));
            }
        }

        private ICommand saveCommand;
        public ICommand SaveCommand => saveCommand ?? (saveCommand = new RelayCommand(SaveCommandExecute));

        private void SaveCommandExecute(Object obj)
        {
            DataContainer.SaveVenuesChanged();
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(DeleteCommandExecute));

        private void DeleteCommandExecute(Object obj)
        {
            Venue v = Session.GetData.GetVenueById(curVenue.VenueId);
            Session.ModifyData.DeleteVenue(v);
            Console.WriteLine(v.VenueId + " deleted");
            DataContainer.InitVenueObservList();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
