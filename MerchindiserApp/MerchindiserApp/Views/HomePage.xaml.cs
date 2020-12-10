using MerchindiserApp.ViewModels;
using System;
using System.IO;
using Xamarin.Forms;

namespace MerchindiserApp.Views
{
    public partial class HomePage : ContentPage
    {
        HomePageViewModel _viewModel;

        public HomePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new HomePageViewModel();
        }

        async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());

        }

        async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());

        }

        async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientPage());

        }
    }
}