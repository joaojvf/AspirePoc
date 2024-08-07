using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using AspirePoc.Core.UseCases.Books.GetBooks;
using AspNetCore.IQueryable.Extensions.Filter;
using Microsoft.EntityFrameworkCore;

namespace AspirePoc.Infrastructure.SqlServer.Repositories
{
    public class BookRepository(ApplicationContext _context) : IBookRepository
    {
        public async Task<int> CreateBookAsync(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<Book?> GetBookAsync(int id) => await _context.
            Books
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Book> GetBooksQueryAsync(GetBooksRequest request)
        {
            var query = _context.Books.AsQueryable().Filter(request);
            return query;
        }

        public async Task<bool> HaveABookWithSameNameAndAuthorAsync(string tittle, string authorName) => await _context.Books.AnyAsync(
                x => x.Tittle.ToUpper() == tittle.ToUpper()
                && x.AuthorName.ToUpper() == authorName.ToUpper());

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
