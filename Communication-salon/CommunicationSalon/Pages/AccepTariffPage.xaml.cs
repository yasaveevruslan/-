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
    /// Логика взаимодействия для AccepTariffPage.xaml
    /// </summary>
    public partial class AccepTariffPage : Page
    {
        public AccepTariffPage()
        {
            InitializeComponent();
        }

        private void BAccept_Click(object sender, RoutedEventArgs e)
        {
            if(DGClientService.SelectedItem is ClientService clientService)
            {
                clientService.Accept = true;
                App.DB.SaveChanges();
                Refresh();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            DGClientService.ItemsSource = App.DB.ClientService.Where(x => x.Accept == false).ToList();
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;
        }
    }
}
