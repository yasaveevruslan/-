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
    /// Логика взаимодействия для ClientMainPage.xaml
    /// </summary>
    public partial class ClientMainPage : Page
    {
        public ClientMainPage()
        {
            InitializeComponent();
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;
            ClientFrame.Navigate(new ServicesPage());

        }

        private void BAllConnectService_Click(object sender, RoutedEventArgs e)
        {
            ClientFrame.Navigate(new ConnectServicesPage());
        }

        private void BAllServices_Click(object sender, RoutedEventArgs e)
        {
            ClientFrame.Navigate(new ServicesPage());
        }
    }
}
