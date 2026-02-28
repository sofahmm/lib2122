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
        public static List<string> sorts { get; set; }
        public static List<Gender> genders { get; set; }
        public ReadersPage()
        {
            InitializeComponent();
            readers = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.ToList());
            sorts = new List<string> { "Сбросить сортировку", "A -> Я", "Я -> А" };
            sortCmb.ItemsSource = sorts;
            genders = new List<Gender>(ConnectionString.libraryKIUEntities.Gender.ToList());
            this.DataContext = this;
        }

        private void searchTb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var fio = searchTb.Text;
            readersLv.ItemsSource = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.
                Where(i => i.FIO.Contains(fio)).ToList());

        }

        private void sortCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sortCmb.SelectedItem.ToString() == "A -> Я")
            {
                readersLv.ItemsSource = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.
                OrderBy(i => i.FIO).ToList());
            }
            else if (sortCmb.SelectedItem.ToString() == "Сбросить сортировку")
                readersLv.ItemsSource = readers;
            else
            {
                readersLv.ItemsSource = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.
                OrderByDescending(i => i.FIO).ToList());
            }
        }

        private void GenderFilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gen = GenderFilterCmb.SelectedItem as Gender;
            readersLv.ItemsSource = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.
                Where(i => i.IdGender == gen.Id).ToList());
        }

        private void AddPageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddReaderPage());
        }
    }
}
