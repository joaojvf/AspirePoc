namespace AspirePoc.Core.Exceptions
{
    public class BookAlreadyAddedException(string tittle, string author) : Exception($"The book {tittle} of {author} already exists.") { }
    public class BookInvalidUpdateException(int id) : Exception($"Invalid book properties was tried update for id {id}") { }
    public class BookNotFoundException(int id) : Exception($"No book with id {id} was found.") { }
}
