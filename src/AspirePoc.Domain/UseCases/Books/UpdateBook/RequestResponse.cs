using MediatR;

namespace AspirePoc.Core.UseCases.Books.UpdateBook
{
    public record UpdateBookRequest(int Id, string Tittle, string Description, DateTime ReleaseDate, string AuthorName, int CategoryId) 
        : BookBaseRequest(Tittle, Description, ReleaseDate, AuthorName, CategoryId), IRequest<UpdateBookResponse>;

    public record UpdateBookResponse();
}
