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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        User contextUser;
        public RegistrationPage(User user)
        {
            InitializeComponent();
            CBRole.ItemsSource = App.DB.Role.Where(x => x.Id != 1).ToList();
            contextUser = user;
            contextUser.BirthDate = DateTime.Now;
            DataContext = contextUser;
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;


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

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var validationContext = new ValidationContext(contextUser);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            if(!Validator.TryValidateObject(contextUser, validationContext, results, true))
            {
                foreach(var result in results)
                {
                    error += $"{result}\n";
                }
            }
            if(!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
                return;
            }
            var user = App.DB.User.FirstOrDefault(x => x.Login == contextUser.Login);
            if(user != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }
            App.DB.User.Add(contextUser);
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }
        
    }
}
