This is a project that uses Dapper, SqlServer and MinimalApi

## Packages
Dapper
System.Data.SqlClient

## Access Database Implementation
I configured SqlServer locally with a SqlServer project. You can see the implementation in SqlServer.Schema project.

This class fetches the database configuration and its methods execute the procedures directly in the database.

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

## Repository Implementation

The class methods define which procedure will be executed and what the expected return should be.

    public class BookRepository : IBookRepository
    {
        private readonly IDatabaseAccess _db;

        public BookRepository(IDatabaseAccess db) => _db = db;

        public async Task<IEnumerable<Book>> GetBooksAsync()
            => await _db.GetDataAsync<Book, object>("dbo.GetAllBooksSP", new { });

        public async Task<Book?> GetBookAsync(int id) =>
            (await _db.GetDataAsync<Book, object>("dbo.GetBookByIdSP", new { Id = id })).FirstOrDefault();

        public async Task InsertBookAsync(Book book) =>
            await _db.SaveDataAsync("dbo.InsertBookSP", new { book.Name, book.Description, book.ISBN, book.PublishedAt });

        public async Task UpdateBookAsync(Book book) =>
            await _db.SaveDataAsync("dbo.UpdateBookSP", book);

        public async Task DeleteBookAsync(int id) =>
            await _db.SaveDataAsync("dbo.DeleteBookSP", new { Id = id });
    }


## Give a Star 
If you found this Implementation helpful or used it in your Projects, do give it a star. Thanks!

## This project was built with
* [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Dapper](https://github.com/DapperLib/Dapper)
* [Swagger](https://swagger.io/)
* [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

## My contacts
* [LinkedIn](https://www.linkedin.com/in/henry-saldanha-3b930b98/)
