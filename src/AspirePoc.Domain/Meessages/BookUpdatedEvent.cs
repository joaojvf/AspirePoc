using AspirePoc.Core.Entities;
using AspirePoc.Core.Meessages.Base;

namespace AspirePoc.Core.Meessages
{
    public class BookUpdatedEvent : StoredEvent, IEvent
    {

        public BookUpdatedEvent(Book book) : base(book.Guid, nameof(BookUpdatedEvent), book)
        {   
        }
    }
}
