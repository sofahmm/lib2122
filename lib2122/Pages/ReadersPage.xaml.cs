using lib2122.DbConnection;
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

namespace lib2122.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReadersPage.xaml
    /// </summary>
    public partial class ReadersPage : Page
    {
        public static List<Reader> readers { get; set; }
        public ReadersPage()
        {
            InitializeComponent();
            readers = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.ToList());

            this.DataContext = this;
        }

        private void searchTb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var fio = searchTb.Text;
            readersLv.ItemsSource = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.Where(i => i.FIO.Contains(fio)).ToList());

        }
    }
}
