using Api.Models;
using Domain;
using Repository;

namespace Api;

public static class EndPointsConfiguration
{
    public static WebApplication ConfigureEndPoints(this WebApplication app)
    {
        app.MapGet("/Books", GetBooksAsync);
        app.MapGet("/Books/{id}", GetBookAsync);
        app.MapPost("/Books", InsertBookAsync);
        app.MapPut("/Books", UpdateBookAsync);
        app.MapDelete("/Books", DeleteBookAsync);
        return app;
    }

    private static async Task<IResult> GetBooksAsync(IBookRepository repository)
    {
        var books = await repository.GetBooksAsync();
        return Results.Ok(books.Select(c => (BookResponse)c));

    }

    private static async Task<IResult> GetBookAsync(int id, IBookRepository repository)
    {
        var book = await repository.GetBookAsync(id);

        if (book is null)
            return Results.NotFound();

        return Results.Ok((BookResponse)book);
    }

    private static async Task<IResult> InsertBookAsync(InsertBookRequest request, IBookRepository repository)
    {
        var book = (Book)request;
        await repository.InsertBookAsync(book);
        return Results.Created(nameof(InsertBookAsync), (BookResponse)book);
    }

    private static async Task<IResult> UpdateBookAsync(UpdateBookRequest request, IBookRepository repository)
    {
        var book = (Book)request;
        await repository.UpdateBookAsync(book);
        return Results.Ok((BookResponse)book);
    }

    private static async Task<IResult> DeleteBookAsync(int id, IBookRepository repository)
    {
        await repository.DeleteBookAsync(id);
        return Results.Accepted();
    }
}