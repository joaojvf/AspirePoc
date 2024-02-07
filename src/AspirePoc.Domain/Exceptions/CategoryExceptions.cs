namespace AspirePoc.Core.Exceptions
{
    public class CategoryNotFoundException(int id) : Exception($"No category with id {id} was found.") { }
}
