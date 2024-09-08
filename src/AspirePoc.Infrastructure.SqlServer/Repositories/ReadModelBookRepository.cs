using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;

namespace AspirePoc.Infrastructure.SqlServer.Repositories
{
    public class ReadModelBookRepository(ApplicationContext _context) : IReadModelBookRepository
    {

        public async Task CreateReadModelBookAsync(BookReadModel book)
        {
            await _context.AddAsync(book);
        }

        public Task<Book?> GetReadModelBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public Task UpdateReadModelBookAsync(BookReadModel book)
        {
            throw new NotImplementedException();
        }
    }
}
