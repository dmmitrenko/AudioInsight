using AudioInsight.Infrastructure.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace AudioInsight.DataContext.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly IMongoCollection<T> _collection;

    public Repository(MongoDbContext context, string collectionName)
    {
        _collection = context.Database.GetCollection<T>(collectionName);
    }

    public async Task Add(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task Delete(Guid id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<T> Get(Expression<Func<T, bool>> filter)
    {
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> IsEntityExists(Expression<Func<T, bool>> filter)
    {
        return await _collection.Find(filter).Limit(1).AnyAsync();
    }

    public async Task<T> Update(T entity)
    {
        var filter = Builders<T>.Filter.Eq("Id", (Guid)typeof(T).GetProperty("Id").GetValue(entity));
        var updateDefinitions = new List<UpdateDefinition<T>>();

        foreach (var property in typeof(T).GetProperties())
        {
            var value = property.GetValue(entity);
            if (value != null)
            {
                updateDefinitions.Add(Builders<T>.Update.Set(property.Name, value));
            }
        }

        if (!updateDefinitions.Any())
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        var update = Builders<T>.Update.Combine(updateDefinitions);

        var options = new FindOneAndUpdateOptions<T>
        {
            ReturnDocument = ReturnDocument.After
        };

        return await _collection.FindOneAndUpdateAsync(filter, update, options);
    }
}
