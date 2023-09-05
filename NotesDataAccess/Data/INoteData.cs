using NotesDataAccess.Models;

namespace NotesDataAccess.Data
{
    public interface INoteData
    {
        Task<NoteModel?> DeleteAsync(int id);
        Task<IEnumerable<NoteModel>> GetAllAsync();
        Task<NoteModel?> GetAsync(int id);
        Task<NoteModel?> InsertAsync(NoteModel noteModel);
        Task<NoteModel?> UpdateAsync(NoteModel noteModel);
    }
}