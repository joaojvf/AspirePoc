using AspirePoc.Core.Entities;

namespace AspirePoc.Core.Abstractions.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryAsync(int id);
        Task<Category?> GetCategoryAsync(string name);
        Task AddCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
