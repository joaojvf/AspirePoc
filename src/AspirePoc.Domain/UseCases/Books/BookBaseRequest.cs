namespace AspirePoc.Core.UseCases.Books
{
    public record BookBaseRequest(string Tittle, string Description, DateTime ReleaseDate, string AuthorName, int CategoryId);
}
