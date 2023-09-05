using NotesDataAccess.DbAccess;
using NotesDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesDataAccess.Data
{
    /// <summary>
    /// Data access and processing for Note models
    /// </summary>
    public class NoteData : INoteData
    {
        private readonly ISqlDataAccess _dataAccess;

        public NoteData(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        /// <summary>
        /// Load all notes
        /// </summary>
        /// <returns>List of notes</returns>
        public Task<IEnumerable<NoteModel>> GetAllAsync()
        {
            return _dataAccess.LoadData<NoteModel, dynamic>("dbo.spNote_GetAll", new { });
        }

        /// <summary>
        /// Get a note by id
        /// </summary>
        /// <param name="id">Id of the note</param>
        /// <returns>Note or NULL if not found</returns>
        public async Task<NoteModel?> GetAsync(int id)
        {
            var result = await _dataAccess.LoadData<NoteModel, dynamic>("dbo.spNote_Get", new { Id = id });
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Store note
        /// </summary>
        /// <param name="noteModel"></param>
        /// <returns>The stored node, including the updated Id</returns>
        public async Task<NoteModel?> InsertAsync(NoteModel noteModel)
        {
            // TODO: Sanitize input
            var result = await _dataAccess.SaveData<NoteModel, dynamic>(
                "dbo.spNote_Insert",
                new { noteModel.Title, noteModel.Owner, noteModel.Content });
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Update a note
        /// </summary>
        /// <param name="noteModel"></param>
        /// <returns>The updated note</returns>
        public async Task<NoteModel?> UpdateAsync(NoteModel noteModel)
        {
            // TODO: Sanitize input
            var result = await _dataAccess.SaveData<NoteModel, NoteModel>(
                "dbo.spNote_Update",
                noteModel);
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Delet a note
        /// </summary>
        /// <param name="id">Note id</param>
        /// <returns>Deleted note</returns>
        public async Task<NoteModel?> DeleteAsync(int id)
        {
            var result = await _dataAccess.SaveData<NoteModel, dynamic>(
                "dbo.spNote_Delete",
                new { Id = id });
            return result.FirstOrDefault();
        }
    }
}
