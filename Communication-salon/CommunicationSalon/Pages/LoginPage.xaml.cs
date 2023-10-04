using CommunicationSalon.Models;
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

namespace CommunicationSalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = App.DB.User.FirstOrDefault(u => u.Login == TBLogin.Text && u.Login == PBPassword.Password);
            if(user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            App.loggedUser = user;
            if(user.RoleId == 1) //Клиент
            {
                NavigationService.Navigate(new ClientMainPage());
            }
            if(user.RoleId == 2) //Менеджер
            {
                NavigationService.Navigate(new MainManagerPage());
            }
            if (user.RoleId == 3) //Специалист по связи
            {
                NavigationService.Navigate(new CommunicationsSpecialistMainPage());
            }
            if (user.RoleId == 4) //Маркетолог
            {
                NavigationService.Navigate(new ServicesPage());
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage(new User()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.BBack.Visibility = Visibility.Collapsed;

        }
    }
}
