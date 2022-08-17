using Domain;

namespace Repository;

public interface IBookRepository
{
    Task DeleteBookAsync(int id);
    Task<Book?> GetBookAsync(int id);
    Task<IEnumerable<Book>> GetBooksAsync();
    Task InsertBookAsync(Book book);
    Task UpdateBookAsync(Book book);
}