using Domain;

namespace Api.Models;

public class BookResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedAt { get; set; }

    public static implicit operator BookResponse(Book request)
    {
        if (request is null)
            return null;

        return new BookResponse
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            ISBN = request.ISBN,
            PublishedAt = request.PublishedAt
        };
    }
}
