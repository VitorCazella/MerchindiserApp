using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MerchindiserApp.Models
{
    public class Ticket
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        [NotNull]
        public string Status { get; set; }
        public string Description { get; set; }
        [NotNull] //foreign key
        public int Client_ID { get; set; }
    }
}
