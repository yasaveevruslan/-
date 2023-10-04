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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
        }

        private void BSendCommunicationsSpecialist_Click(object sender, RoutedEventArgs e)
        {
            if(DGClientService.SelectedItem is ClientService clientService)
            {
                clientService.Accept = false;
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
            DGClientService.ItemsSource = App.DB.ClientService.Where(x => x.Accept == null).ToList();
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;

        }
    }
}
