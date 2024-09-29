using AudioInsight.Infrastructure.Queue;

namespace AudioInsight.Application.Consumers;

public class MessageConsumerFactory : IMessageConsumerFactory
{
    private readonly Dictionary<string, IMessageConsumer> _consumers;

    public MessageConsumerFactory(IEnumerable<IMessageConsumer> consumers)
    {
        _consumers = consumers.ToDictionary(c => c.RoutingKey, c => c);
    }

    public IMessageConsumer GetConsumer(string routingKey)
    {
        return _consumers.TryGetValue(routingKey, out var consumer) ? consumer : null;
    }

    public IEnumerable<IMessageConsumer> GetAllConsumers()
    {
        return _consumers.Values;
    }
}
