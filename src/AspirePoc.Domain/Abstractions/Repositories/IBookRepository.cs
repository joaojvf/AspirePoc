using AspirePoc.Core.Entities;
using AspirePoc.Core.UseCases.Books.GetBooks;

namespace AspirePoc.Core.Abstractions.Repositories
{
    public interface IBookRepository
    {
        Task<int> CreateBookAsync(Book book);
        Task<Book?> GetBookAsync(int id);
        IQueryable<Book> GetBooksQueryAsync(GetBooksRequest request);
        Task<bool> HaveABookWithSameNameAndAuthorAsync(string tittle, string authorName);
        Task SaveChangesAsync();
    }
}
