namespace AudioInsight.Infrastructure.Queue;

public interface IMessageConsumer
{
    string RoutingKey { get; }
    Task Consume(string message);
}
