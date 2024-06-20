using AspirePoc.Core.Abstractions;
using AspirePoc.Core.Entities;
using MediatR;

namespace AspirePoc.Core.UseCases.Categories.PublishCategory
{
    public class PublishCategoryHandler(IMessageBus _messageBus) : IRequestHandler<PublishCategoryRequest, PublishCategoryResponse>
    {
        public Task<PublishCategoryResponse> Handle(PublishCategoryRequest request, CancellationToken cancellationToken)
        {
            _messageBus.PublishMessage<string>(request.CategoryName, "CreatedCategory");
            return Task.FromResult(new PublishCategoryResponse());
        }
    }
}
