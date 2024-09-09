using AspirePoc.Core.Entities.Base;
using AspirePoc.Core.UseCases.Books.GetBooks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspirePoc.Infrastructure.SqlServer.Books
{
    public class GetBooksHandler(ApplicationContext context) : IRequestHandler<GetBooksRequest, PagedList<GetBooksResponse>>
    {
        public Task<PagedList<GetBooksResponse>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var booksQuery = context.BooksReadModel.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(request.Tittle))
            {
                booksQuery = booksQuery.Where(b => b.Title.Contains(request.Tittle));
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                booksQuery = booksQuery.Where(b => b.Description.Contains(request.Description));
            }

            var pagedBooks = booksQuery
                .OrderBy(b => b.Title)
                .Select(b => new GetBooksResponse(b.DeserializedBook));

            var res = PagedList<GetBooksResponse>.Create(pagedBooks, request.Page, request.PageSize);
            return Task.FromResult(res);
        }
    }
}
