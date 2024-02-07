using AspirePoc.Core.Entities;

namespace AspirePoc.Core.Abstractions.Repositories
{
    public interface IBookRepository
    {
        Task<int> CreateBookAsync(Book book);
        Task<Book?> GetBookAsync(int id);
        Task<bool> HaveABookWithSameNameAndAuthorAsync(string tittle, string authorName);
    }
}
