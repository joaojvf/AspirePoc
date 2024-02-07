using AspirePoc.Core.Abstractions;
using EasyNetQ;

namespace AspirePoc.Infrastructure.RabbitMQ
{
    internal class RabbitMQMessageBus : IMessageBus
    {
        private IBus _bus;

        public RabbitMQMessageBus(string connectionString)
        {
            _bus = RabbitHutch.CreateBus(connectionString);

        }
        public bool IsConnected => _bus?.Advanced.IsConnected ?? false;

        public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            _bus.PubSub.Subscribe(subscriptionId, onMessage);
        }
        public void PublishMessage<T>(T message, string routingKey)
        {
            _bus.PubSub.Publish(message, routingKey);
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage)
        {
            _bus.PubSub.Subscribe(subscriptionId, onMessage);
        }

        public void Dispose()
        {
            _bus.Dispose();
        }
    }
}
