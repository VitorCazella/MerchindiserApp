using System;
using System.IO;
using Xamarin.Forms;

namespace MerchindiserApp.Views
{
    public partial class AboutPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public AboutPage()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }

        async public void OnLogInButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

    }
}