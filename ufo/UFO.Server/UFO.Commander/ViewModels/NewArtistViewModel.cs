using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using UFO.Commander.Annotations;
using UFO.Commander.Util;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class NewArtistViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<CategoryViewModel> categories;
        public ObservableCollection<CategoryViewModel> Categories => categories ?? (categories = DataContainer.GetCategoryObservColl());

        private ObservableCollection<CountryViewModel> countries;
        public ObservableCollection<CountryViewModel> Countries => countries ?? (countries = DataContainer.GetCountryObservColl());


        private CategoryViewModel curCategory;

        public CategoryViewModel CurCategory
        {
            get { return curCategory; }
            set
            {
                curCategory = value;
                OnPropertyChanged(nameof(CurCategory));
            }
        }

        private CountryViewModel curCountry;

        public CountryViewModel CurCountry
        {
            get { return curCountry; }
            set
            {
                curCountry = value;
                OnPropertyChanged(nameof(CurCountry));
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

        private string mail;

        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                OnPropertyChanged(nameof(Mail));
            }
        }

       

        private string image;

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private string video;

        public string Video
        {
            get { return video; }
            set
            {
                video = value;
                OnPropertyChanged(nameof(Video));
            }
        }

        private ICommand saveArtistCommand;

        public ICommand SaveArtistCommand
            => saveArtistCommand ?? (saveArtistCommand = new RelayCommand(SaveArtistCommandExecute));

        private async void SaveArtistCommandExecute(object obj)
        {
            Artist artist = new Artist
            {
                Name = name,
                EMail = mail,
                Category = DataContainer.FindCategoryById(curCategory.Id),
                Country = DataContainer.FindCountryById(curCountry.Code),
                Picture = BlobData.CreateBlobData(Image),
                PromoVideo = Video
            };
            var worked = await Task.Run(() => Session.ModifyData.ModifyArtist(artist));
            Console.WriteLine(artist.Name + "inserted: " + worked);
            DataContainer.InitArtistObservList();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}