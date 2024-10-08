﻿using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using AspirePoc.Core.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspirePoc.Infrastructure.SqlServer.Repositories
{
    public class BookRepository(ApplicationContext _context, IMediator _mediator) : IBookRepository
    {

        public async Task<int> CreateBookAsync(Book book)
        {            
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<List<Book>> GetAllToRebuildAsync(CancellationToken cancellationToken)
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookAsync(int id) => await _context.
            Books
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Book>> GetBooksById(IReadOnlyList<Guid> guids) => await _context
            .Books
            .AsNoTracking()
            .Include(x => x.Category)            
            .Where(x => guids.Contains(x.Guid))
            .ToListAsync();

        public async Task<bool> HaveABookWithSameNameAndAuthorAsync(string tittle, string authorName) => await _context.Books.AnyAsync(
                x => x.Tittle.ToUpper() == tittle.ToUpper()
                && x.AuthorName.ToUpper() == authorName.ToUpper());

        public async Task SaveChangesAsync() {            
            await _mediator.PublishMessages(_context);
            await _context.SaveChangesAsync();
        }

    }
}
