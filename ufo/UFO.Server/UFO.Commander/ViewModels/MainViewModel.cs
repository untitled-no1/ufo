using System.ComponentModel;
using System.Runtime.CompilerServices;
using UFO.Commander.Annotations;

namespace UFO.Commander.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private INotifyPropertyChanged viewModel = new LoginViewModel();

        public INotifyPropertyChanged ViewModel
        {
            get { return viewModel; }
            set { if (viewModel != value) { viewModel = value; OnPropertyChanged("ViewModel"); } }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}