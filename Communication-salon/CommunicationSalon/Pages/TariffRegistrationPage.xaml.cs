using CommunicationSalon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Логика взаимодействия для TariffRegistrationPage.xaml
    /// </summary>
    public partial class TariffRegistrationPage : Page
    {
        ClientService contextClientService;
        public TariffRegistrationPage()
        {
            InitializeComponent();
            CBClient.ItemsSource = App.DB.User.Where(x => x.RoleId == 1).ToList();
            CBService.ItemsSource = App.DB.Service.ToList();
            contextClientService = new ClientService();
            contextClientService.EndDate = DateTime.Now;
            DataContext = contextClientService;
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;

        }

        private void BAddClientService_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var validationContext = new ValidationContext(contextClientService);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            if (!Validator.TryValidateObject(contextClientService, validationContext, results, true))
            {
                foreach (var result in results)
                {
                    error += $"{result}\n";
                }
            }
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
                return;
            }
            var client = CBClient.SelectedItem as User;
            var count = App.DB.ClientService.Where(x => x.Disabled != true).Count(x => x.User.Id == client.Id);
            if(count >= 5)
            {
                MessageBox.Show("Любой клиент может оформить максимум 5 тарифов");
                return;
            }
            App.DB.ClientService.Add(contextClientService);
            App.DB.SaveChanges();
            MessageBox.Show("Требуется дополнительно отправить специалисту связи");
            contextClientService = new ClientService();
            contextClientService.EndDate = DateTime.Now;
            DataContext = null;
            DataContext = contextClientService;
        }
    }
}
