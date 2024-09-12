using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using AspirePoc.Core.Messages;
using MediatR;
using System.Text.Json;

namespace AspirePoc.Core.UseCases.Books.SyncBookReadModel
{
    public class SyncBookReadModelHandler(IReadModelBookRepository _bookRepository) : INotificationHandler<BookCreatedEvent>, INotificationHandler<BookUpdatedEvent>
    {
        public async Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
        {
            var bookReadModel = GetReadModelBook(notification);
            await _bookRepository.CreateReadModelBookAsync(bookReadModel);
            await _bookRepository.SaveChangesAsync();
        }

        public async Task Handle(BookUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var bookReadModel = GetReadModelBook(notification);
            await _bookRepository.UpdateReadModelBookAsync(bookReadModel);
            await _bookRepository.SaveChangesAsync();
        }

        private static BookReadModel GetReadModelBook(StoredEvent notification)
        {
            var book = JsonSerializer.Deserialize<Book>(notification.Data);

            var bookRead = new BookReadModel
            {
                Guid = book!.Guid,
                Id = book.Id,
                Title = book.Tittle,
                Description = book.Description,
                SerializedObject = notification.Data
            };
            return bookRead;
        }
    }
}
