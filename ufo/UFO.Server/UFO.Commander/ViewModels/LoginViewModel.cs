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
    class LoginViewModel : INotifyPropertyChanged
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
                }
                OnPropertyChanged(nameof(Password));
            }
        }

        private ICommand loginCommand;
        public ICommand LoginCommand => loginCommand ?? (loginCommand = new RelayCommand(LoginCommandExecute));

        private async void LoginCommandExecute(object o)
        {
            var username = UserName;
            var password = Password;
            var validLogin = await Task.Run(() => BusinessLayerFactory.CreateAuthentificationInstance(username, password));

            Console.WriteLine("name: " + UserName);
            Console.WriteLine("Pw: " + Password);
            if (validLogin.IsLoggedIn())
            {
                Console.WriteLine("Logged in");

            }
            else
            {
                Console.WriteLine("NOT logged in");
            }
    }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
