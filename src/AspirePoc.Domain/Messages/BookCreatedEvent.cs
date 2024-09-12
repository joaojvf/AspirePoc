using AspirePoc.Core.Entities;
using AspirePoc.Core.Messages.Base;

namespace AspirePoc.Core.Messages
{
    public class BookCreatedEvent : StoredEvent, IEvent
    {

        public BookCreatedEvent(Book book) : base(book.Guid, nameof(BookCreatedEvent), book)
        {

        }
    }
}
