using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UFO.Commander.Annotations;
using UFO.Commander.Util;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class NotificationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DataContainer.NotificationPack> Notifications => DataContainer.ConcernedPerformances;

        


        private ICommand sendCommand;

        public ICommand SendCommand
            => sendCommand ?? (sendCommand = new RelayCommand(SendCommandExecute));

        private void SendCommandExecute(Object obj)
        {
            Dictionary<string, List<DataContainer.NotificationPack>> MailMap = InitMailMap();
            foreach (var entry in MailMap)
            {
                string message = BuildMailBody(entry.Value);
                SendMails(entry.Key, message);
            }

        }

        private string BuildMailBody(List<DataContainer.NotificationPack> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in list)
            {
                var tmp = entry.Performance;
                sb.Append(tmp.DateString + " ")
                    .Append(tmp.Hour + ":00 ")
                    .Append(tmp.VenueName + ", ")
                    .Append(tmp.LocationName + " => ")
                    .Append(entry.Reason)
                    .AppendLine();
            }
            return sb.ToString();
        }

        private void SendMails(string recipient, string data)
        {
            using (var mailMessage = new MailMessage("guybrush830@gmail.com", recipient)
            {
                Subject = "Recent Changes",
                Body = data,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true
            })
            using (var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 25,
                EnableSsl = true,
                Timeout = 10000,
                Credentials = new NetworkCredential("guybrush830@gmail.com", "Admin__1"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
            })
            {
                smtpClient.Send(mailMessage);
            }
        }

        private Dictionary<string, List<DataContainer.NotificationPack>> InitMailMap()
        {
            Dictionary<string, List<DataContainer.NotificationPack>> mm = new Dictionary<string, List<DataContainer.NotificationPack>>();
            foreach (var n in Notifications)
            {
                var mail = n.Performance.GetDbPerformance.Artist.EMail;
                if (mm.ContainsKey(mail))
                {
                    mm[mail].Add(n);
                }
                else
                {
                    var tmp = new List<DataContainer.NotificationPack> { n };
                    mm[mail] = tmp;
                }
            }
            return mm;
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
