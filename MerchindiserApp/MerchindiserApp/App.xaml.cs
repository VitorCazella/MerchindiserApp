using MerchindiserApp.Services;
using MerchindiserApp.Views;
using MerchindiserApp.Database;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using MerchindiserApp.Models;

namespace MerchindiserApp
{
    public partial class App : Application
    {
        static IDatabase database;

        public static IDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new IDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db3"));
                    App.Database.SaveUserAsync(new Users
                    {
                        Name = "Vitor",
                        Password = "secret",
                        ContactDetails = "vitorniogwehngpwg",
                        Type = true
                    });
                    App.Database.SaveUserAsync(new Users
                    {
                        Name = "Finn",
                        Password = "1234",
                        ContactDetails = "finn@gmail.com",
                        Type = false
                    });
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
