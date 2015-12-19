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
        public static List<Artist> ChangedArtists = new List<Artist>();
        public ObservableCollection<ArtistViewModel> Artists { get; } = new ObservableCollection<ArtistViewModel>();
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

        public ArtistDataViewModel()
        {
            InitList();
        }

        private void InitList()
        {
            var dbArtists = Session.GetData.GetAllArtists();
            foreach (var a in dbArtists)
            {
                Artists.Add(new ArtistViewModel(a));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand saveCommand;
        public ICommand SaveCommand => saveCommand ?? (saveCommand = new RelayCommand(SaveCommandExecute));
        
        private async void SaveCommandExecute(object obj)
        {
            var result = await Task.Run(() => Session.ModifyData.ModifyArtists(ChangedArtists));
            Console.WriteLine(ChangedArtists.Count + " Artists changed: " + result);
            ChangedArtists.Clear();
        }


    }
}
