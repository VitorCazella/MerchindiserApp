using MerchindiserApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MerchindiserApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        ProfilePageViewModel _viewModel;

        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ProfilePageViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var login = new Database.loginStatus();
            Name.Text = login.GetUser().Name;
            ContactDets.Text = login.GetUser().ContactDetails;
            Type.Text = login.GetType();
        }
    }
}