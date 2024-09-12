using AspirePoc.Core.Entities;
using AspirePoc.Core.Messages.Base;

namespace AspirePoc.Core.Messages
{
    public class BookDocument : StoredEvent, IDocument
    {
        public BookDocument(Book book) : base(book.Guid, nameof(BookDocument), book)
        {
        }
    }
}
