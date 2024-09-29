﻿namespace AudioInsight.Infrastructure.Settings;

public class QueueConnectionSettings
{
    public string HostName { get; set; }
    public int Port { get; set; }
    public string ExchangeName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } 
}
