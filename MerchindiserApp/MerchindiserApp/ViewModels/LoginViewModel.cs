using MerchindiserApp.Views;
using MerchindiserApp.Database;
using Xamarin.Forms;
using System;
using System.ComponentModel;

namespace MerchindiserApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        IDatabase dataAccess;

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }


        public Command LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClickedAsync);
        }

        private async void OnLoginClickedAsync(object obj)
        {

            var user = await App.Database.GetUserAsync(name);

            try
            {

                if (name != user.Name || password != user.Password)
                {
                    DisplayInvalidLoginPrompt();
                }
                else
                {
                    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                    Application.Current.MainPage = new AppShell();
                }
            }
            catch (Exception e)
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}
