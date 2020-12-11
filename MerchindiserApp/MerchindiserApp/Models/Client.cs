using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MerchindiserApp.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactDetails { get; set; }
        public string Location { get; set; }
    }
}
