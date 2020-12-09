using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MerchindiserApp.Models
{
    class Users
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ContactDetails { get; set; }
        [NotNull]
        public Boolean Type { get; set; }
    }
}
