using AspirePoc.Core.Entities;
using AspirePoc.Core.Entities.Base;
using MediatR;

namespace AspirePoc.Core.Helpers
{
    public static class Extensions
    {
        public static async Task PublishMessages(this IMediator mediator, ApplicationContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Messages != null && x.Entity.Messages.Any());

            var domainMessages = domainEntities
                .SelectMany(x => x.Entity.Messages)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearMessages());

            var tasks = domainMessages
                .Select(async (message) =>
                {
                    await mediator.Publish(message);
                });


            var storedEvents = domainMessages.OfType<StoredEvent>().ToList();
            await context.StoredEvents.AddRangeAsync(storedEvents);
            await context.SaveChangesAsync();

            await Task.WhenAll(tasks);
        }
    }
}
