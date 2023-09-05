using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace NotesDataAccess.DbAccess
{
    /// <summary>
    /// Thin wrapper for dapper
    /// </summary>
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Load data from the database
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="U">Input type</typeparam>
        /// <param name="storedProcedure">Name of the stored procedure in the db</param>
        /// <param name="parameters">Input value for the sp</param>
        /// <param name="connectionId">Connection string id from the app settings</param>
        /// <returns>Result of the stored procedure</returns>
        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters,
                                                 string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Modify data in the db
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <typeparam name="U">Input Type</typeparam>
        /// <param name="storedProcedure">Name of the stored procedure in the db</param>
        /// <param name="parameters">Input value for the sp, in most cases the Id</param>
        /// <param name="connectionId">Connection string id from the app settings</param>
        /// <returns>Returns the modifyed value from the db</returns>
        public async Task<T> SaveData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            return await connection.QueryFirstAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
