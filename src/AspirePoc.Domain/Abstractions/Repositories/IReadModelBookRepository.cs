using AspirePoc.Core.Entities;

namespace AspirePoc.Core.Abstractions.Repositories
{
    public interface IReadModelBookRepository
    {
        Task CreateReadModelBookAsync(BookReadModel book);
        Task UpdateReadModelBookAsync(BookReadModel book);
        Task<Book?> GetReadModelBookAsync(int id);
        Task SaveChangesAsync();
        Task CreateOrReplaceAllReadModelBooksAsync(List<BookReadModel> readModelBooks, CancellationToken cancellationToken);
        Task CreateOrReplaceReadModelBooksAsync(List<BookReadModel> readModelBooks, CancellationToken cancellationToken);
    }
}
