using AspirePoc.Core.Entities.Base;
using AspirePoc.Core.UseCases.Books.GetBooks;
using AspNetCore.IQueryable.Extensions.Filter;
using MediatR;

namespace AspirePoc.Infrastructure.SqlServer.Books
{
    public class GetBooksHandler(ApplicationContext context) : IRequestHandler<GetBooksRequest, PagedList<GetBooksResponse>>
    {
        public Task<PagedList<GetBooksResponse>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var booksQuery = context.Books.AsQueryable()
               .Filter(request)
               .Select(x => new GetBooksResponse(
                   x.Tittle,
                   x.Description,
                   x.ReleaseDate,
                   x.AuthorName,
                   x.Category.Name));

            var res = PagedList<GetBooksResponse>.Create(booksQuery, request.Page, request.PageSize);
            return Task.FromResult(res);
        }
    }
}
