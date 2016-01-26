using System;
using System.ComponentModel;
using System.Security.RightsManagement;
using UFO.Commander.Util;
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
                Category c = DataContainer.FindCategoryById(value);
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
                Country c = DataContainer.FindCountryById(value);
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
            DataContainer.AddToArtistChanged(artist);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
