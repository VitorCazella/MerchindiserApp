using System;
using System.IO;
using Xamarin.Forms;

namespace MerchindiserApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
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