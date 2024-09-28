namespace AudioInsight.Infrastructure.Settings;

public record MongoDbSettings
{
    public string ConnectionString { get; init; }
    public string DatabaseName { get; init; }
}
