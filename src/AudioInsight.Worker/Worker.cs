using AudioInsight.Infrastructure.Queue;
using AudioInsight.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace AudioInsight.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMessageConsumerFactory _consumerFactory;
    private readonly QueueConnectionSettings _connectionSettings;
    private IConnection _connection;
    private IModel _channel;

    public Worker(
        ILogger<Worker> logger,
        IMessageConsumerFactory consumerFactory,
        IOptions<QueueConnectionSettings> connectionSettings)
    {
        _logger = logger;
        _consumerFactory = consumerFactory;
        _connectionSettings = connectionSettings.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        InitializeRabbitMQ();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            _logger.LogInformation($"Received message for routing key '{ea.RoutingKey}': {message}");

            var messageConsumer = _consumerFactory.GetConsumer(ea.RoutingKey);
            if (messageConsumer != null)
            {
                try
                {
                    await messageConsumer.Consume(message);
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error processing message for routing key '{ea.RoutingKey}': {ex.Message}");
                }
            }
            else
            {
                _logger.LogError($"No consumer found for routing key '{ea.RoutingKey}'");
            }
        };

        foreach (var consumerInstance in _consumerFactory.GetAllConsumers())
        {
            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName, exchange: _connectionSettings.ExchangeName, routingKey: consumerInstance.RoutingKey);

            _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }

        await Task.CompletedTask;
    }

    private void InitializeRabbitMQ()
    {
        var factory = new ConnectionFactory() 
        { 
            HostName = _connectionSettings.HostName, 
            UserName = _connectionSettings.Username,
            Password = _connectionSettings.Password,
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: _connectionSettings.ExchangeName, type: ExchangeType.Topic);

        _logger.LogInformation("RabbitMQ connection established and exchange declared.");
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }
}
