namespace AspirePoc.Core.Exceptions
{
    public class BookAlreadyAddedException(string tittle, string author) : Exception($"The book {tittle} of {author} already exists.") { }
    public class BookNotFoundException(int id) : Exception($"No book with id {id} was found.") { }
}
