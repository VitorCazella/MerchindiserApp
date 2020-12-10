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
            var login = new Database.loginStatus();

            try
            {
                if (!login.GetStatus())
                {
                    if (name != user.Name || password != user.Password && !login.GetStatus())
                    {
                        DisplayInvalidLoginPrompt();
                    }
                    else
                    {
                        // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                        login.SaveUser(user);
                        Application.Current.MainPage = new AppShell();
                    }
                }
                else
                {
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
