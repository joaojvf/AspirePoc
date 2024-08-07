using AspirePoc.Core.Entities.Base;
using AspNetCore.IQueryable.Extensions;
using MediatR;

namespace AspirePoc.Core.UseCases.Books.GetBooks
{
    public record GetBooksRequest(string? Tittle, string? Description, int Page, int PageSize) : IRequest<PagedList<GetBooksResponse>>, ICustomQueryable;

    public record GetBooksResponse(string Tittle, string Description, DateTime ReleaseDate, string Author, string Category);
}
