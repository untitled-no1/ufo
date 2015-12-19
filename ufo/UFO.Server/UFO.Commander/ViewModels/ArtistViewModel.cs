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
    public class ArtistViewModel : INotifyPropertyChanged
    {
        private Artist artist;

        public string Name
        {
            get { return artist?.Name; }
            set
            {
                artist.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string EMail
        {
            get { return artist?.EMail; }
            set
            {
                artist.EMail = value;
                OnPropertyChanged(nameof(EMail));
            }
        }

        public string PicturePath
        {
            get { return artist?.Picture.Path; }
            set
            {
                artist.Picture = BlobData.CreateBlobData(value);
                OnPropertyChanged(nameof(PicturePath));
            }
        }

        public string PromoVideo
        {
            get { return artist?.PromoVideo; }
            set
            {
                artist.PromoVideo = value;
                OnPropertyChanged(nameof(PromoVideo));
            }
        }

        public ArtistViewModel() :this(new Artist())
        {    
        }

        public ArtistViewModel(Artist a)
        {
            this.artist = a;
            this.artist = artist ?? new Artist();
            artist.PromoVideo = artist.PromoVideo ?? "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var alreadyChangedArtist = FindArtistById(artist);
            if (alreadyChangedArtist != null)
            {
                ArtistDataViewModel.ChangedArtists.Remove(alreadyChangedArtist);
            }
            ArtistDataViewModel.ChangedArtists.Add(artist);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Artist FindArtistById(Artist artist)
        {
            foreach (var a in ArtistDataViewModel.ChangedArtists)
            {
                if (artist.ArtistId == a.ArtistId)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
