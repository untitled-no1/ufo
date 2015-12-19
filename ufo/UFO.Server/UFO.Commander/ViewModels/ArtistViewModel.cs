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

        public string CategoryId
        {
            get { return artist?.Category.CategoryId; }
            set
            {
                Category c = FindCategoryById(value);
                if (c != null)
                {
                    artist.Category = c;
                    OnPropertyChanged(nameof(CategoryId));
                }
            }
        }

        public string CountryId
        {
            get { return artist?.Country.Code; }
            set
            {
                Country c = FindCountryById(value);
                if (c != null)
                {
                    artist.Country = c;
                    OnPropertyChanged(nameof(CountryId));
                }
            }
        }

        

        public string PicturePath
        {
            get
            {
                if (artist?.Picture.Path == null)
                {
                    return "http://www.focusonthecoast.com/wp-content/uploads/2014/02/making-music-placeholder-image.jpg";
                }
                return artist?.Picture.Path;

            }
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

        public Category FindCategoryById(string id)
        {
            foreach (var c in ArtistDataViewModel.Categories)
            {
                if (c.CategoryId == id)
                {
                    return c;
                }
            }
            return null;
        }

        private Country FindCountryById(string id)
        {
            foreach (var c in ArtistDataViewModel.Countries)
            {
                if (c.Code == id)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
