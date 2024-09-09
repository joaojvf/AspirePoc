using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspirePoc.Infrastructure.SqlServer.Repositories
{
    public class ReadModelBookRepository(ApplicationContext _context) : IReadModelBookRepository
    {

        public async Task CreateReadModelBookAsync(BookReadModel book)
        {
            await _context.AddAsync(book);
        }

        public async Task<Book?> GetReadModelBookAsync(int id)
        {
            var readModel = await _context.BooksReadModel.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return readModel is null ? null : readModel.DeserializedBook;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public Task UpdateReadModelBookAsync(BookReadModel book)
        {
            throw new NotImplementedException();
        }
    }
}
