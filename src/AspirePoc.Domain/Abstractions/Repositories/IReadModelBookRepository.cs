using AspirePoc.Core.Entities;
using AspirePoc.Core.UseCases.Books.GetBooks;

namespace AspirePoc.Core.Abstractions.Repositories
{
    public interface IReadModelBookRepository
    {
        Task CreateReadModelBookAsync(BookReadModel book);
        Task UpdateReadModelBookAsync(BookReadModel book);
        Task<Book?> GetReadModelBookAsync(int id);
        Task SaveChangesAsync();
    }
}
