using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.ViewModels;

namespace UFO.Commander.Views
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : BaseMetroDialog
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            LoginViewModel vm = (LoginViewModel) DataContext;
            var result = await vm.LoginCommandExecute();
            if (result)
                await ((MetroWindow) Application.Current.MainWindow).HideMetroDialogAsync(this);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }
    }
}
