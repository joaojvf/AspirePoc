using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using AspirePoc.Core.Events;
using MediatR;
using System.Text.Json;

namespace AspirePoc.Core.UseCases.Books.SyncBookReadModel
{
    public class SyncBookReadModelHandler(IReadModelBookRepository _bookRepository) : INotificationHandler<BookCreatedEvent>
    {
        public async Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
        {
            await SyncReadModel(notification.Book);
        }

        private async Task SyncReadModel(Book book)
        {
            var serializedBook = JsonSerializer.Serialize(book);

            var bookRead = new BookReadModel
            {
                Guid = book.Guid,
                Id = book.Id,
                Title = book.Tittle,
                Description = book.Description,
                SerializedObject = serializedBook
            };

            await _bookRepository.CreateReadModelBookAsync(bookRead);
            await _bookRepository.SaveChangesAsync();
        }
    }
}
