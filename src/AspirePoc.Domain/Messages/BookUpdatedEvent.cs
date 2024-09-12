using AspirePoc.Core.Entities;
using AspirePoc.Core.Messages.Base;

namespace AspirePoc.Core.Messages
{
    public class BookUpdatedEvent : StoredEvent, IEvent
    {

        public BookUpdatedEvent(Book book) : base(book.Guid, nameof(BookUpdatedEvent), book)
        {   
        }
    }
}
