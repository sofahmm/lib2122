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
using lib2122.DbConnection;
using lib2122.Windows;

namespace lib2122
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Employee> employees {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //создаем контейнеры для того, что введет пользователь
            string login = loginTb.Text.Trim();
            string password = passwordPb.Password.Trim();

            //заполняем динамический массив записями из бд
            employees = new List<Employee>(ConnectionString.libraryKIUEntities.Employee.ToList());

            //ищем нужного юзера
            Employee currentUser = employees.FirstOrDefault(i => i.Login.Trim() == login && i.Password.Trim() == password);
            if (currentUser != null)
            {
                MenuBibloteqarWindow menuBibloteqarWindow = new MenuBibloteqarWindow();
                menuBibloteqarWindow.Show();
            }
            else
                MessageBox.Show("Not good");


        }
    }
}
