using MediatR;

namespace AspirePoc.Core.Events.Base
{
    public abstract class DomainEvent : INotification
    {
        public Guid AggregateId { get; private set; }
        public DateTime OcurredOn { get; private set; }
        public string EntityType { get; private set; }

        protected DomainEvent(Guid aggregateId, string entityType) {
            AggregateId = aggregateId;
            EntityType = entityType;
            OcurredOn = DateTime.Now;
        }
    }
}
