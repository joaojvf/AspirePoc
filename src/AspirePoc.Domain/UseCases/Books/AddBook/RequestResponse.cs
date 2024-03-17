using MediatR;

namespace AspirePoc.Core.UseCases.Books.AddBook
{
    public record AddBookRequest(string Tittle, string Description, DateTime ReleaseDate, string AuthorName, int CategoryId)
    : BookBaseRequest(Tittle, Description, ReleaseDate, AuthorName, CategoryId), IRequest<AddBookResponse>;

    public record AddBookResponse(int Id);
}
