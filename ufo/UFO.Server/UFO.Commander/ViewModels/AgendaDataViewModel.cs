using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UFO.Commander.Annotations;
using UFO.Commander.Util;

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
            get { return curPerformance;;}
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
       
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
