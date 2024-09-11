using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspirePoc.Infrastructure.SqlServer.Repositories
{
    public class StoredEventsRepository(ApplicationContext _context) : IStoredEventsRepository
    {
        public async Task AddEvent<TEvent>(TEvent evento) where TEvent : StoredEvent
        {
            await _context.StoredEvents.AddAsync(evento);
        }

        public async Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId)
        {
            var events = await _context.StoredEvents
                .Where(x => x.AggregateId == aggregateId)
                .OrderBy(x => x.OcurredOn)
                .ToListAsync();

            return events;
        }
    }
}
