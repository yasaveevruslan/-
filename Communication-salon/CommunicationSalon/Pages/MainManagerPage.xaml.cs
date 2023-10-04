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
    /// Логика взаимодействия для MainManagerPage.xaml
    /// </summary>
    public partial class MainManagerPage : Page
    {
        public MainManagerPage()
        {
            InitializeComponent();
            ManagerFrame.Navigate(new TariffRegistrationPage());
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;
        }

        private void BAddServices_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Navigate(new TariffRegistrationPage());
        }

        private void BAllConnectService_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Navigate(new ManagerPage());
        }
    }
}
