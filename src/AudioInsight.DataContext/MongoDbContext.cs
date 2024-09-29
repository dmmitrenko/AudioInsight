using AudioInsight.Domain.Model;
using AudioInsight.Infrastructure.Settings;
using MongoDB.Driver;

namespace AudioInsight.DataContext;
public class MongoDbContext
{
    public IMongoDatabase Database { get; }

    public MongoDbContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        Database = client.GetDatabase(settings.DatabaseName);
        CreateIndexes();
    }

    public IMongoCollection<Category> Categories => Database.GetCollection<Category>("Categories");

    public IMongoCollection<Call> Calls => Database.GetCollection<Call>("Calls");

    private void CreateIndexes()
    {
        var indexKeysDefinition = Builders<Category>.IndexKeys.Ascending(c => c.Title);
        var indexOptions = new CreateIndexOptions { Unique = true };
        var indexModel = new CreateIndexModel<Category>(indexKeysDefinition, indexOptions);
        Categories.Indexes.CreateOne(indexModel);
    }
}
