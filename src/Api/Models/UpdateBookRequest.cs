using Domain;

namespace Api.Models;

public class UpdateBookRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedAt { get; set; }

    public static implicit operator Book(UpdateBookRequest request)
    {
        if (request is null)
            return null;

        return new Book
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            ISBN = request.ISBN,
            PublishedAt = request.PublishedAt
        };
    }
}
