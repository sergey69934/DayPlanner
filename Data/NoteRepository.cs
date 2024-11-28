using DayPlanner.Models;
using SQLite;

namespace DayPlanner.Data
{
    public class NoteRepository : INoteRepository
    {
        #region Private Fields

        private SQLiteAsyncConnection _connection;
        private string _dbPath;

        #endregion Private Fields

        #region Private Methods

        private async Task Init()
        {
            if (_connection != null)
            {
                return;
            }

            _connection = new SQLiteAsyncConnection(_dbPath,
                SQLiteOpenFlags.Create |
                SQLiteOpenFlags.ReadWrite |
                SQLiteOpenFlags.SharedCache);

            await _connection.CreateTableAsync<NoteModel>();
        }

        #endregion Private Methods

        #region Public Constructors

        public NoteRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> DeleteNoteAsync(NoteModel note)
        {
            await Init();
            return await _connection.DeleteAsync(note);
        }

        public async Task<List<NoteModel>> GetNotesAsync()
        {
            await Init();
            return await _connection.Table<NoteModel>().ToListAsync();
        }

        public async Task<List<NoteModel>> GetFilteredNotesAsync(string query)
        {
            await Init();

            if (string.IsNullOrWhiteSpace(query))
            {
                return await _connection.Table<NoteModel>().ToListAsync();
            }

            return await _connection.Table<NoteModel>()
                                    .Where(note => note.Title.Contains(query) || note.Text.Contains(query))
                                    .ToListAsync();
        }

        public async Task<int> SaveNoteAsync(NoteModel note)
        {
            await Init();
            if (note.ID != 0)
                return await _connection.UpdateAsync(note);
            else
                return await _connection.InsertAsync(note);
        }

        #endregion Public Methods
    }
}
