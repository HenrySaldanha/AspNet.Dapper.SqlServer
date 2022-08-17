namespace Repository.DatabaseAccess;

public interface IDatabaseAccess
{
    Task<IEnumerable<T>> GetDataAsync<T, U>(string storedProcedure, U parameters);
    Task SaveDataAsync<T>(string storedProcedure, T parameters);
}