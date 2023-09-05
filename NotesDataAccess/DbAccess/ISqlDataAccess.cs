namespace NotesDataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task<T> SaveData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    }
}