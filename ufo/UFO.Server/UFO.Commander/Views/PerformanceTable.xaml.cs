using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using UFO.Commander.Util;

namespace UFO.Commander.Views
{
    /// <summary>
    /// Interaction logic for PerformanceTable.xaml
    /// </summary>
    public partial class PerformanceTable : UserControl
    {
        public PerformanceTable()
        {
            InitializeComponent();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(PerformanceGrid.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("LocationName");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
