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
using System.Windows.Shapes;

namespace lib2122.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuBibloteqarWindow.xaml
    /// </summary>
    public partial class MenuBibloteqarWindow : Window
    {
        public MenuBibloteqarWindow()
        {
            InitializeComponent();
        }

        private void readerBtn_Click(object sender, RoutedEventArgs e)
        {
            navFrame.NavigationService.Navigate(new Pages.ReadersPage());
        }

        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void authorBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
