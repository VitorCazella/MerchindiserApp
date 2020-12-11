using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using MerchindiserApp.Models;

namespace MerchindiserApp.Database
{
    public class IDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public IDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Users>().Wait();
            _database.CreateTableAsync<Client>().Wait();
            _database.CreateTableAsync<Ticket>().Wait();
        }

        public Task<List<Users>> GetUsersAsync()
        {
            return _database.Table<Users>().ToListAsync();
        }

        public Task<Users> GetUserAsync(int id)
        {
            return _database.Table<Users>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<Users> GetUserAsync(string name)
        {
            return _database.Table<Users>()
                            .Where(i => i.Name == name)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(Users user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(Users user)
        {
            return _database.DeleteAsync(user);
        }

        public Task<int> SaveTicketAsync(Ticket ticket)
        {
            if (ticket.ID != 0)
            {
                return _database.UpdateAsync(ticket);
            }
            else
            {
                return _database.InsertAsync(ticket);
            }
        }

        public Task<List<Ticket>> GetTicketsAsync()
        {
            return _database.Table<Ticket>().ToListAsync();
        }
    }
}
