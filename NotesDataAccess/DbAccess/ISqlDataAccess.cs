namespace NotesDataAccess.DbAccess
{
    /// <summary>
    /// Thin wrapper for dapper
    /// </summary>
    public interface ISqlDataAccess
    {
        /// <summary>
        /// Load data from the database
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="U">Input type</typeparam>
        /// <param name="storedProcedure">Name of the stored procedure in the db</param>
        /// <param name="parameters">Input value for the sp</param>
        /// <param name="connectionId">Connection string id from the app settings</param>
        /// <returns>Result of the stored procedure</returns>
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");

        /// <summary>
        /// Modify data in the db
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <typeparam name="U">Input Type</typeparam>
        /// <param name="storedProcedure">Name of the stored procedure in the db</param>
        /// <param name="parameters">Input value for the sp, in most cases the Id</param>
        /// <param name="connectionId">Connection string id from the app settings</param>
        /// <returns>Returns the modifyed value from the db</returns>
        Task<IEnumerable<T>> SaveData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    }
}