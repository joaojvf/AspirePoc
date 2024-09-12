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

        public async Task UpdateReadModelBookAsync(BookReadModel book)
        {
            var existentBook = await _context.BooksReadModel.FindAsync(book.Guid);
            _context.BooksReadModel.Remove(existentBook!);
            await _context.BooksReadModel.AddAsync(book!);

        }

        public async Task CreateOrReplaceReadModelBooksAsync(List<BookReadModel> readModelBooks, CancellationToken cancellationToken)
        {
            var idsToDelete = readModelBooks.Select(book => book.Id).ToList();
            var strategy = _context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    var books = await _context.BooksReadModel.Where(x => idsToDelete.Contains(x.Id)).ToListAsync();
                    _context.BooksReadModel.RemoveRange(books);
                    _context.BooksReadModel.AddRange(readModelBooks);

                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while replacing the books.", ex);
                }
            });

        }

        public async Task CreateOrReplaceAllReadModelBooksAsync(List<BookReadModel> readModelBooks, CancellationToken cancellationToken)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = _context.Database.BeginTransaction();
                try
                {

                    var allBooks = await _context.BooksReadModel.ToListAsync();
                    _context.BooksReadModel.RemoveRange(allBooks);
                    _context.BooksReadModel.AddRange(readModelBooks);

                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while replacing all the books.", ex);
                }
            });
        }
    }
}
