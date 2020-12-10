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

        public bool GetStatus()
        {
            return IsLoggedin;
        }

        public void LogOut()
        {
            IsLoggedin = false;
            LoggedUser = null;
        }
    }
}
