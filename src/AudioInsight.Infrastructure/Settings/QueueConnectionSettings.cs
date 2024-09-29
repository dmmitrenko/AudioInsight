namespace AudioInsight.Infrastructure.Settings;

public class QueueConnectionSettings
{
    public string Hostname { get; set; } = "localhost";
    public int Port { get; set; } = 5672;
    public string ExchangeName { get; set; } = "audio_exchange";
    public string Username { get; set; } = "guest";
    public string Password { get; set; } = "guest";
}
