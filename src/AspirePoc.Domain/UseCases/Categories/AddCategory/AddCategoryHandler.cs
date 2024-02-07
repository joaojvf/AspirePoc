using AspirePoc.Core.Abstractions.Repositories;
using MediatR;

namespace AspirePoc.Core.UseCases.Categories.AddCategory
{
    public class AddCategoryHandler(ICategoryRepository _categoryRepository) : IRequestHandler<AddCategoryRequest>
    {
        public async Task Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryAsync(request.Category.Name);
            if (category is not null)
            {
                return;
            }

            await _categoryRepository.AddCategoryAsync(request.Category);
        }
    }
}

