using AspirePoc.Core.Entities;
using AspirePoc.Core.Events.Base;

namespace AspirePoc.Core.Events
{
    public class BookCreatedEvent : DomainEvent
    {
        public Book Book { get; init; }
        public BookCreatedEvent(Book book) : base(book.Guid, nameof(BookCreatedEvent))
        {
            Book = book;
        }
    }
}
