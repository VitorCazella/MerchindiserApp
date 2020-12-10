using MerchindiserApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchindiserApp.Database
{
    public class loginStatus
    {
        private static bool IsLoggedin;
        private static Users LoggedUser;

        static loginStatus()
        {
            IsLoggedin = false;
        }

        public Users GetUser() { return LoggedUser; }

        public bool GetStatus()
        {
            return IsLoggedin;
        }

        public string GetType()
        {
            if (LoggedUser.Type)
            {
                return "Supervisor";
            }
            else
            {
                return "Merchindiser";
            }
        }

        public void SaveUser(Users user)
        {
            LoggedUser = user;
            IsLoggedin = true;
        }

        public void LogOut()
        {
            IsLoggedin = false;
            LoggedUser = null;
        }
    }
}
