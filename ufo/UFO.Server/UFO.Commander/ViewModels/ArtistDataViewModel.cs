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
    public class ArtistDataViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ArtistViewModel> Artists => DataContainer.GetArtistObservColl();
        public event PropertyChangedEventHandler PropertyChanged;

        private ArtistViewModel curArtist;

        public ArtistViewModel CurArtist
        {
            get { return curArtist; }
            set
            {
                curArtist = value;
                OnPropertyChanged(nameof(CurArtist));
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
            DataContainer.SaveArtistsChanged();
        }





    }
}
