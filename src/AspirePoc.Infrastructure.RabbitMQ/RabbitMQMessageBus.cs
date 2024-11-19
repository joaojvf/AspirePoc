using AspirePoc.Core.Abstractions;
using EasyNetQ;
using Polly;
using Polly.Retry;

namespace AspirePoc.Infrastructure.RabbitMQ
{
    internal class RabbitMQMessageBus : IMessageBus
    {
        private IBus _bus;
        private readonly AsyncRetryPolicy _retryPolicy;


        public RabbitMQMessageBus(string connectionString)
        {
            _bus = RabbitHutch.CreateBus(connectionString);
            _retryPolicy = Policy
                .Handle<EasyNetQException>()
                .Or<TimeoutException>()
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (exception, timeSpan, retryCount, context) =>
                    {
                        Console.WriteLine($"Retry {retryCount} for SubscribeAsync due to: {exception.Message}");
                    });

        }
        public bool IsConnected => _bus?.Advanced.IsConnected ?? false;

        public async void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            await _retryPolicy.ExecuteAsync(async () =>
            {
                await _bus.PubSub.SubscribeAsync(subscriptionId, onMessage);
            });
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
