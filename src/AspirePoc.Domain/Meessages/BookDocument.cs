using AspirePoc.Core.Entities;
using AspirePoc.Core.Meessages.Base;

namespace AspirePoc.Core.Meessages
{
    public class BookDocument : StoredEvent, IDocument
    {
        public BookDocument(Book book) : base(book.Guid, nameof(BookDocument), book)
        {
        }
    }
}
