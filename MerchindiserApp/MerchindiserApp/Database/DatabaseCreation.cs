using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MerchindiserApp.Database
{
    public class DatabaseCreation : IDatabase
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "Database.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}
