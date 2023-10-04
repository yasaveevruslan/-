using CommunicationSalon.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
    /// Логика взаимодействия для RegistrateNewClientPage.xaml
    /// </summary>
    public partial class RegistrateNewClientPage : Page
    {
        User contextUser;
        public RegistrateNewClientPage(User user)
        {
            InitializeComponent();
            contextUser = user;
            contextUser.Role = App.DB.Role.FirstOrDefault(x => x.Id == 1);
            contextUser.BirthDate = DateTime.Now;
            DataContext = contextUser;
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;

        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var validationContext = new ValidationContext(contextUser);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            if (!Validator.TryValidateObject(contextUser, validationContext, results, true))
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
            App.DB.User.Add(contextUser);
            App.DB.SaveChanges();
            MessageBox.Show("Клиент добавлен в систему");
            contextUser = new User();
            contextUser.Role = App.DB.Role.FirstOrDefault(x => x.Id == 1);
            contextUser.BirthDate = DateTime.Now;
            DataContext = contextUser;
        }

        private void BAddPhoto_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new OpenFileDialog() { Filter = ".png, .jpg, .jpeg | *.png; *.jpg; *.jpeg;" };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextUser.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextUser;
            }
        }
    }
}
