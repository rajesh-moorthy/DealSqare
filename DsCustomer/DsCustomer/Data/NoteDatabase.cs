using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;

namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Transactions>().Wait();
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

        public Task<int> DeleteNoteAsync(Transactions note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
