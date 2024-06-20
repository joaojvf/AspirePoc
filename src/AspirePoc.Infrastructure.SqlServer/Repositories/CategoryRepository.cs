using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspirePoc.Infrastructure.SqlServer.Repositories
{
    public class CategoryRepository(ApplicationContext _context) : ICategoryRepository
    {
        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int id) => await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Category?> GetCategoryAsync(string name) => await _context.Categories.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
    }
}
