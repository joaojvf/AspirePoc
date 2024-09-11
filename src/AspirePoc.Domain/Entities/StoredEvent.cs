using AspirePoc.Core.Meessages.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace AspirePoc.Core.Entities
{
    public class StoredEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid AggregateId { get; private set; }
        public DateTime OcurredOn { get; private set; }
        public string EntityType { get; private set; }
        public string Data { get; private set; }

        public string DataType { get; private set; }

        protected StoredEvent() { }

        protected StoredEvent(Guid aggregateId, string entityType, object data)
        {
            AggregateId = aggregateId;
            EntityType = entityType;
            DataType = ResolveDataType(data);
            OcurredOn = DateTime.Now;
            Data = JsonSerializer.Serialize(data);
        }

        private string ResolveDataType(object data)
        {
            if (this is IEvent)
            {
                return "Event";
            }
            else if (this is IDocument)
            {
                return "Document";
            }

            return "Unknown";
        }
    }
}
