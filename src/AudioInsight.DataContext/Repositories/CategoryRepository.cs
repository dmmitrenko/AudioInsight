using AudioInsight.Domain;
using AudioInsight.Infrastructure.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace AudioInsight.DataContext.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly MongoDbContext _context;

    public CategoryRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task Add(Category category)
    {
        await _context.Categories.InsertOneAsync(category);
    }

    public async Task Delete(Guid id)
    {
        await _context.Categories.DeleteOneAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.Find(_ => true).ToListAsync();
    }

    public async Task<Category> GetById(Guid id)
    {
        return await _context.Categories.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> IsCategoryExists(Expression<Func<Category, bool>> filter)
    {
        return await _context.Categories.Find(filter).Limit(1).AnyAsync();
    }

    public async Task<Category> Update(Category category)
    {
        var filter = Builders<Category>.Filter.Eq(c => c.Id, category.Id);

        var updateDefinitions = new List<UpdateDefinition<Category>>();

        if (!string.IsNullOrEmpty(category.Title))
        {
            updateDefinitions.Add(Builders<Category>.Update.Set(c => c.Title, category.Title));
        }

        if (category.Points != null && category.Points.Any())
        {
            updateDefinitions.Add(Builders<Category>.Update.Set(c => c.Points, category.Points));
        }

        if (!updateDefinitions.Any())
        {
            return await _context.Categories.Find(filter).FirstOrDefaultAsync();
        }

        var update = Builders<Category>.Update.Combine(updateDefinitions);

        var options = new FindOneAndUpdateOptions<Category>
        {
            ReturnDocument = ReturnDocument.After
        };

        var updatedCategory = await _context.Categories
            .FindOneAndUpdateAsync(filter, update, options);

        return updatedCategory;
    }
}
