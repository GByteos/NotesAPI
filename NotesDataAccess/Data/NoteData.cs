using NotesDataAccess.DbAccess;
using NotesDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesDataAccess.Data
{
    /// <inheritdoc/>
    public class NoteData : INoteData
    {
        private readonly ISqlDataAccess _dataAccess;

        public NoteData(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<IEnumerable<NoteModel>> GetAllAsync()
        {
            return _dataAccess.LoadData<NoteModel, dynamic>("dbo.spNote_GetAll", new { });
        }

        public async Task<NoteModel?> GetAsync(int id)
        {
            var result = await _dataAccess.LoadData<NoteModel, dynamic>("dbo.spNote_Get", new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<NoteModel?> InsertAsync(NoteModel noteModel)
        {
            // TODO: Sanitize input
            var result = await _dataAccess.SaveData<NoteModel, dynamic>(
                "dbo.spNote_Insert",
                new { noteModel.Title, noteModel.Owner, noteModel.Content });
            return result.FirstOrDefault();
        }

        public async Task<NoteModel?> UpdateAsync(NoteModel noteModel)
        {
            // TODO: Sanitize input
            var result = await _dataAccess.SaveData<NoteModel, NoteModel>(
                "dbo.spNote_Update",
                noteModel);
            return result.FirstOrDefault();
        }

        public async Task<NoteModel?> DeleteAsync(int id)
        {
            var result = await _dataAccess.SaveData<NoteModel, dynamic>(
                "dbo.spNote_Delete",
                new { Id = id });
            return result.FirstOrDefault();
        }
    }
}
