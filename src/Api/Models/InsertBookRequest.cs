using Domain;

namespace Api.Models;

public class InsertBookRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedAt { get; set; }

    public static implicit operator Book(InsertBookRequest request)
    {
        if (request is null)
            return null;

        return new Book
        {
            Name = request.Name,
            Description = request.Description,
            ISBN = request.ISBN,
            PublishedAt = request.PublishedAt
        };
    }
}
