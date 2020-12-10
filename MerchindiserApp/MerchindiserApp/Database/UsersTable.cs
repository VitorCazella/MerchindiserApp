using MerchindiserApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MerchindiserApp.Database
{
    class UsersTable : DatabaseCreation
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Users> Users { get; set; }

        public UsersTable()
        {
            database = DependencyService.Get<UsersTable>().DbConnection();
            database.CreateTable<Users>();
            this.Users = new ObservableCollection<Users>(database.Table<Users>());
            AddNewUser();
        }

        public void AddNewUser()
        {
            this.Users.Add(new Users
            {
                Name = "Vitor",
                Password = "",
                ContactDetails = "vitor.cazella@yahoo.com",
                Type = true
            });
        }

        public IEnumerable<Users> GetFilteredUsers(string name)
        {
            lock (collisionLock)
            {
                var query = from cust in database.Table<Users>()
                            where cust.Name == name
                            select cust;
                return query.AsEnumerable();
            }
        }
        public IEnumerable<Users> GetFilteredUsers(Boolean type)
        {
            lock (collisionLock)
            {
                return database.Query<Users>($"SELECT * FROM Users WHERE Type = {type.ToString()}").AsEnumerable();
            }
        }
        public Users GetUserByID(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Users>().FirstOrDefault(Users => Users.ID == id);
            }
        }
        public int SaveCustomer(Users userInstance)
        {
            lock (collisionLock)
            {
                if (userInstance.ID != 0)
                {
                    database.Update(userInstance);
                    return userInstance.ID;
                }
                else
                {
                    database.Insert(userInstance);
                    return userInstance.ID;
                }
            }
        }
        public void SaveAllCustomers()
        {
            lock (collisionLock)
            {
                foreach (var userInstance in this.Users)
                {
                    if (userInstance.ID != 0)
                    {
                        database.Update(userInstance);
                    }
                    else
                    {
                        database.Insert(userInstance);
                    }
                }
            }
        }
    }
}
