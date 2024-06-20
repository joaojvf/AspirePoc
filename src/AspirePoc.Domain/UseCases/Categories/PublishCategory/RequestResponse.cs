using AspirePoc.Core.Entities;
using MediatR;

namespace AspirePoc.Core.UseCases.Categories.PublishCategory
{
    public record PublishCategoryRequest(string CategoryName) : IRequest<PublishCategoryResponse>;
    public record PublishCategoryResponse();
}
