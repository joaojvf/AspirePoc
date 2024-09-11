using AspirePoc.Core.Entities;

namespace AspirePoc.Core.Abstractions.Repositories
{
    public interface IStoredEventsRepository
    {
        Task AddEvent<TEvent>(TEvent evento) where TEvent : StoredEvent;
        Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId);
    }
}