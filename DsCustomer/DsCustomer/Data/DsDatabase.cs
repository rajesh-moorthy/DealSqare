using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;

namespace Notes.Data
{
    public class DsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public DsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Transactions>().Wait();
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<Transactions>> GetNotesAsync()
        {
            return _database.Table<Transactions>().ToListAsync();
        }

        public Task<Transactions> GetNoteAsync(int id)
        {
            return _database.Table<Transactions>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Transactions note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteNoteAsync(Transactions note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
