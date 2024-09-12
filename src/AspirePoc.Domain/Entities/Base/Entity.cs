using AspirePoc.Core.Messages.Base;

namespace AspirePoc.Core.Entities.Base
{
    public abstract class Entity
    {
        public Guid Guid { get; set; }
        private List<IMessage> _messages = [];
        public IReadOnlyCollection<IMessage> Messages => _messages.AsReadOnly();

        protected Entity()
        {
            Guid = Guid.NewGuid();
        }

        public void AddMessage(IMessage evento)
        {
            _messages.Add(evento);
        }

        public void ClearMessages()
        {
            _messages.Clear();
        }
    }
}
