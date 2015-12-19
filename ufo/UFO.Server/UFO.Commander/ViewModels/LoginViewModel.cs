using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UFO.Commander.Annotations;
using UFO.Commander.Util;
using UFO.Server.BLL;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                using (var md5 = MD5.Create())
                {
                    password = Crypto.GetMd5Hash(md5, value);
                    Console.WriteLine(password);
                }
                OnPropertyChanged(nameof(Password));
            }
        }
        
        public async Task<bool> LoginCommandExecute()
        {
            var username = UserName;
            var password = Password;
            var auth = await Task.Run(() => BusinessLayerFactory.CreateAuthentificationInstance(username, password));
            Session.InitSession(auth);

            if (Session.Authentification.IsLoggedIn())
            {
                return true;
            }
            else
            {
                Console.WriteLine("NOT logged in");
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
