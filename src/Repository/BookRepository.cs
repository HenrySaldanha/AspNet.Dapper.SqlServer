using Domain;
using Repository.DatabaseAccess;

namespace Repository.Data;

public class BookRepository : IBookRepository
{
    private readonly IDatabaseAccess _db;

    public BookRepository(IDatabaseAccess db) => _db = db;

    public async Task<IEnumerable<Book>> GetBooksAsync()
        => await _db.ExecuteQueryAsync<Book>("SELECT Id, Name, Description, ISBN, PublishedAt FROM dbo.Book");

    public async Task<Book?> GetBookAsync(int id) =>
        (await _db.GetDataAsync<Book, object>("dbo.GetBookByIdSP", new { Id = id })).FirstOrDefault();

    public async Task InsertBookAsync(Book book) =>
        await _db.SaveDataAsync("dbo.InsertBookSP", new { book.Name, book.Description, book.ISBN, book.PublishedAt });

    public async Task UpdateBookAsync(Book book) =>
        await _db.SaveDataAsync("dbo.UpdateBookSP", book);

    public async Task DeleteBookAsync(int id) =>
        await _db.SaveDataAsync("dbo.DeleteBookSP", new { Id = id });
}
