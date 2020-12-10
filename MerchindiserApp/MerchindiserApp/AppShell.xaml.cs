using MerchindiserApp.ViewModels;
using MerchindiserApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MerchindiserApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var login = new Database.loginStatus();
            login.LogOut();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
