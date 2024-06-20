namespace AspirePoc.Core.Abstractions
{
    public interface IMessageBus : IDisposable
    {
        bool IsConnected { get; }
        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class;
        void PublishMessage<T>(T message, string routingKey);
    }
}
