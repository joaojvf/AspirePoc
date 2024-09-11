using AspirePoc.Core.Entities;
using AspirePoc.Core.Meessages.Base;

namespace AspirePoc.Core.Meessages
{
    public class BookCreatedEvent : StoredEvent, IEvent
    {

        public BookCreatedEvent(Book book) : base(book.Guid, nameof(BookCreatedEvent), book)
        {

        }
    }
}
