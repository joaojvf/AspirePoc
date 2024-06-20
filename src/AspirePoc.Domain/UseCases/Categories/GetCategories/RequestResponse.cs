using AspirePoc.Core.Entities;
using MediatR;

namespace AspirePoc.Core.UseCases.Categories.GetCategories
{
    public record GetCategoriesRequest() : IRequest<GetCategoriesResponse>;
    public record GetCategoriesResponse(IEnumerable<Category> Categories);
}
