namespace AudioInsight.Infrastructure.Queue;

public interface IMessageConsumerFactory
{
    IMessageConsumer GetConsumer(string routingKey);
    IEnumerable<IMessageConsumer> GetAllConsumers();
}
