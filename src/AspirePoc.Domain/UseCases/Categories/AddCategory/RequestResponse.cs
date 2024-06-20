using AspirePoc.Core.Entities;
using MediatR;

namespace AspirePoc.Core.UseCases.Categories.AddCategory
{
    public record AddCategoryRequest(string CategoryName) : IRequest;
}
