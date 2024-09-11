using AspirePoc.Core.Entities;
using AspirePoc.Core.Meessages.Base;

namespace AspirePoc.Core.Meessages
{
    public class BookUpdatedEvent : StoredEvent, IEvent
    {
        public string Tittle { get; set; }

        public BookUpdatedEvent(Book book) : base(book.Guid, nameof(BookUpdatedEvent), book)
        {   
        }
    }
}
