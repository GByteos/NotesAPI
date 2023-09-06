using NotesDataAccess.Models;

namespace NotesDataAccess.Data
{
    /// <summary>
    /// Data access and processing for Note models
    /// </summary>
    public interface INoteData
    {
        /// <summary>
        /// Delet a note
        /// </summary>
        /// <param name="id">Note id</param>
        /// <returns>Deleted note</returns>
        Task<NoteModel?> DeleteAsync(int id);

        /// <summary>
        /// Load all notes
        /// </summary>
        /// <returns>List of notes</returns>
        Task<IEnumerable<NoteModel>> GetAllAsync();

        /// <summary>
        /// Get a note by id
        /// </summary>
        /// <param name="id">Id of the note</param>
        /// <returns>Note or NULL if not found</returns>
        Task<NoteModel?> GetAsync(int id);

        /// <summary>
        /// Store note
        /// </summary>
        /// <param name="noteModel"></param>
        /// <returns>The stored node, including the updated Id</returns>
        Task<NoteModel?> InsertAsync(NoteModel noteModel);

        /// <summary>
        /// Update a note
        /// </summary>
        /// <param name="noteModel"></param>
        /// <returns>The updated note</returns>
        Task<NoteModel?> UpdateAsync(NoteModel noteModel);
    }
}