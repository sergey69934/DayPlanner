using DayPlanner.Models;

namespace DayPlanner.Data
{
    public interface INoteRepository
    {
        Task<int> DeleteNoteAsync(NoteModel note);
        Task<List<NoteModel>> GetNotesAsync();
        Task<List<NoteModel>> GetFilteredNotesAsync(string query);
        Task<int> SaveNoteAsync(NoteModel note);
    }
}
