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
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            if(App.loggedUser.RoleId == 1)
            {
                AddService.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddService.Visibility = Visibility.Visible;
            }
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddServicePage(new Service()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            LVServices.ItemsSource = App.DB.Service.ToList();
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;

        }
    }
}
