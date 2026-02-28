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
    /// Логика взаимодействия для AddReaderPage.xaml
    /// </summary>
    public partial class AddReaderPage : Page
    {
        public static List<Gender> genders {  get; set; }
        public AddReaderPage()
        {
            InitializeComponent();

            genders = new List<Gender>(ConnectionString.libraryKIUEntities.Gender.ToList());
            this.DataContext = this;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Reader reader = new Reader();
            reader.FIO = FioTb.Text.Trim();
            reader.NumberPhone = NumberPhoneTb.Text.Trim();
            reader.Email = EmailTb.Text.Trim();
            reader.BirthDate = BirthDateDb.SelectedDate;
            reader.IdGender = (GenderCmb.SelectedItem as Gender).Id;
            ConnectionString.libraryKIUEntities.Reader.Add(reader);
            ConnectionString.libraryKIUEntities.SaveChanges();
        }
    }
}
