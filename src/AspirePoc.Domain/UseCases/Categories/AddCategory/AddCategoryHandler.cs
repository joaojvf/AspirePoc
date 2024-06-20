using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Exceptions;
using MediatR;

namespace AspirePoc.Core.UseCases.Categories.AddCategory
{
    public class AddCategoryHandler(ICategoryRepository _categoryRepository) : IRequestHandler<AddCategoryRequest>
    {
        public async Task Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryAsync(request.CategoryName);
            if (category is not null)
            {
                throw new CategoryAlreadyExistException(request.CategoryName);
            }

            await _categoryRepository.AddCategoryAsync(new Entities.Category() { Name = request.CategoryName});
        }
    }
}

