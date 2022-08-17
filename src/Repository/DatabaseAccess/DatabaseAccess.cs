using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repository.DatabaseAccess;

public class DatabaseAccess : IDatabaseAccess
{
    private readonly string _connectionString;
    public DatabaseAccess(IConfiguration config) => _connectionString = config.GetConnectionString("SqlServer");

    public async Task<IEnumerable<T>> GetDataAsync<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        return await connection.QueryAsync<T>
            (storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveDataAsync<T>(string storedProcedure, T parameters)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        await connection.ExecuteAsync
            (storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}