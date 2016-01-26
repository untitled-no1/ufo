using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
    public class NewPeformanceViewModel : INotifyPropertyChanged
    {
        public PerformanceViewModel OldPerformance = null;

        private ObservableCollection<ArtistViewModel> artists;
        public ObservableCollection<ArtistViewModel> Artists
            => artists ?? (artists = DataContainer.GetArtistObservColl());

        private ObservableCollection<VenueViewModel> venues;
        public ObservableCollection<VenueViewModel> Venues => venues ?? (venues = DataContainer.GetVenueObservColl());

        private ObservableCollection<String> times;
        public ObservableCollection<String> Times
        {
            get
            {
                if(times == null)
                    times = new ObservableCollection<string>();
                    for (int i = 14; i < 24; ++i)
                    {
                        times.Add(i + ":00");
                    }
                return times;
            }
        }

        private String curTime;
        public String CurTime
        {
            get { return curTime; }
            set
            {
                curTime = value;
                OnPropertyChanged(nameof(CurTime));
            }
        }

        private VenueViewModel curVenue;

        public VenueViewModel CurVenue
        {
            get { return curVenue; }
            set
            {
                curVenue = value;
                OnPropertyChanged(nameof(CurVenue));
            }
        }

        private ArtistViewModel curArtist;

        public ArtistViewModel CurArtist
        {
            get { return curArtist;}
            set
            {
                curArtist = value;
                OnPropertyChanged(nameof(CurArtist));
            }
        }

        private String date;
        public String Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }


        private ICommand savePerformanceCommand;

        public ICommand SavePerformanceCommand
            => savePerformanceCommand ?? (savePerformanceCommand = new RelayCommand(SavePerformanceCommandExecute));

        private async void SavePerformanceCommandExecute(object obj)
        {
            NotificationReason state = NotificationReason.Error;
            DateTime n = DateTime.ParseExact(Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime m = DateTime.ParseExact(curTime, "HH:mm", CultureInfo.InvariantCulture);
            
            Performance newPerformance = new Performance
            {
                Artist = DataContainer.FindArtistByName(CurArtist),
                Venue = DataContainer.FindVenueById(CurVenue),
                DateTime = new DateTime(n.Year, n.Month, n.Day, m.Hour, 0,0)
            };
            Performance dbPerformance = null;
            if (OldPerformance != null)
                dbPerformance = OldPerformance.GetDbPerformance;
            var worked = await Task.Run(() => Session.ModifyData.ModifyPerformance(dbPerformance, newPerformance));
            Console.WriteLine(newPerformance.Artist.Name + " " + newPerformance.Venue.Name + " " + newPerformance.DateTime + " inserted: " + worked);
            Date = "";
            DataContainer.InitPerformanceObservList();
            CurTime = times.First();
            CurArtist = artists.First();
            CurVenue = venues.First();
            if (worked)
                state = NotificationReason.Added;
            if (OldPerformance != null)
                state = NotificationReason.Edited;

            if(state != NotificationReason.Error)
                DataContainer.AddToConcernedPerformances(new PerformanceViewModel(newPerformance), state);
            OldPerformance = null;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
