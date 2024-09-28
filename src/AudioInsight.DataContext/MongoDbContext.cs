using AudioInsight.Domain;
using AudioInsight.Infrastructure.Settings;
using MongoDB.Driver;

namespace AudioInsight.DataContext;
public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
        CreateIndexes();
    }

    public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");

    public IMongoCollection<Call> Calls => _database.GetCollection<Call>("Calls");

    private void CreateIndexes()
    {
        var indexKeysDefinition = Builders<Category>.IndexKeys.Ascending(c => c.Title);
        var indexOptions = new CreateIndexOptions { Unique = true };
        var indexModel = new CreateIndexModel<Category>(indexKeysDefinition, indexOptions);
        Categories.Indexes.CreateOne(indexModel);
    }
}
