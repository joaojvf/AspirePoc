using AspirePoc.Core.Abstractions;
using AspirePoc.Core.UseCases.Categories.AddCategory;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspirePoc.Infrastructure.RabbitMQ.Jobs
{
    public class CategoryHandler(IMessageBus _messageBus, IServiceProvider _serviceProvider) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _messageBus.SubscribeAsync<string>("CreatedCategory", async request => await Handle(request));
            return Task.CompletedTask;
        }

        private async Task Handle(string category)
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            await mediator!.Send(new AddCategoryRequest(category));
        }
    }
}
