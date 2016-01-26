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
    public class AgendaDataViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PerformanceViewModel> Performances => DataContainer.GetPerformanceObservColl();
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<string> dates;
        public ObservableCollection<string> Dates => dates ?? (dates = DataContainer.GetDatesObservColl());

        private string curDate;

        public string CurDate
        {
            get { return curDate; }
            set
            {
                curDate = value;
                DataContainer.RefreshPerformanceObservList(curDate);
                OnPropertyChanged(nameof(CurDate));
            }
        }


        private PerformanceViewModel curPerformance;

        public PerformanceViewModel CurPerformance
        {
            get { return curPerformance;}
            set
            {
                curPerformance = value;
                OnPropertyChanged(nameof(CurPerformance));
            }
        }

        public AgendaDataViewModel()
        {
            CurDate = Dates.First();
        }


        private ICommand deleteCommand;
        public ICommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(DeleteCommandExecute));

        private void DeleteCommandExecute(object obj)
        {
            Performance p = Session.GetData.GetPerformancePerId(curPerformance.DateTime, curPerformance.ArtistId);
            Session.ModifyData.DeletePerformance(p);
            DataContainer.AddToConcernedPerformances(curPerformance, NotificationReason.Deleted);
            Console.WriteLine(p.DateTime + " " + p.Artist + " deleted");
            DataContainer.InitPerformanceObservList();
        }

        private ICommand editCommand;
        public ICommand EditCommand => editCommand ?? (editCommand = new RelayCommand(EditCommandExecute));

        private void EditCommandExecute(object obj)
        {
            var newPerformance = ViewModelLocator.NewPeformanceViewModel;
            newPerformance.CurArtist = DataContainer.FindArtistByNameInObs(curPerformance.ArtistName);
            newPerformance.CurTime = curPerformance.Hour;
            try
            {
                var tmp = DateTime.ParseExact(curPerformance.DateString, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture);
                newPerformance.Date = tmp.ToString("dd.MM.yyyy");
            }
            catch (FormatException e)
            {
                newPerformance.Date = "";
                Console.WriteLine("DATE ERROR!!!!!!: " + e.Message);
            }
            finally
            {
                newPerformance.CurVenue = DataContainer.FindVenueByIdInObs(curPerformance.VenueId);
                newPerformance.OldPerformance = curPerformance;
            }

        }



        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
