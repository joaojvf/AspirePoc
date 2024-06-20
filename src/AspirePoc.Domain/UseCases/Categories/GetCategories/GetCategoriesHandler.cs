using AspirePoc.Core.Abstractions.Repositories;
using MediatR;

namespace AspirePoc.Core.UseCases.Categories.GetCategories
{
    public class PublishCategoryHandler(ICategoryRepository _categoryRepository) : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
    {
        public async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var res = await _categoryRepository.GetCategoriesAsync();
            return new(res);
        }
    }
}
