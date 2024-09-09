using AspirePoc.Core.Entities;
using AspirePoc.Core.Entities.Base;
using MediatR;

namespace AspirePoc.Core.UseCases.Books.GetBooks
{
    public record GetBooksRequest(string? Tittle, string? Description, int Page = 1, int PageSize = 50) : IRequest<PagedList<GetBooksResponse>>;

    public record GetBooksResponse(Book Book);
}
