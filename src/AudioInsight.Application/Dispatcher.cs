using AudioInsight.Contracts.Queue;
using AudioInsight.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AudioInsight.Application;

public class Dispatcher : IDisposable
{
    private readonly QueueConnectionSettings _configuration;
    private IConnection _connection;
    private IModel _channel;


    public Dispatcher(IOptions<QueueConnectionSettings> connectionSettings)
    {
        _configuration = connectionSettings.Value;
        InitializeRabbitMQ();
    }

    private void InitializeRabbitMQ()
    {
        var factory = new ConnectionFactory
        {
            HostName = _configuration.HostName,
            Port = _configuration.Port,
            UserName = _configuration.Username,
            Password = _configuration.Password
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: _configuration.ExchangeName, type: ExchangeType.Topic);
    }

    public void SendMessage(string routingKey, StartAudioAnalysis command)
    {
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));
        _channel.BasicPublish(exchange: _configuration.ExchangeName, routingKey: routingKey, basicProperties: null, body: body);
        Console.WriteLine($"Message sent to exchange '{_configuration.ExchangeName}' with routing key '{routingKey}': {command}");
    }

    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
    }
}
