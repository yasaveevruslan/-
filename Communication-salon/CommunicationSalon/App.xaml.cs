using CommunicationSalon.Models;
using CommunicationSalon.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CommunicationSalon
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CommunicationSalonEntities DB = new CommunicationSalonEntities();
        public static User loggedUser;
        public static MainWindow MainWindowInstance;
        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            RegistrationDescriptors();
        }

        private void RegistrationDescriptors()
        {
            AddDescriptor<Service, ServiceMetadata>();
            AddDescriptor<User, UserMetadata>();
            AddDescriptor<ClientService, ClientServiceMetadata>();

        }

        private void AddDescriptor<T1, T2>()
        {
            var provider = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T1), typeof(T2));
            TypeDescriptor.AddProviderTransparent(provider, typeof(T1));
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.Message);
        }

    }
}
