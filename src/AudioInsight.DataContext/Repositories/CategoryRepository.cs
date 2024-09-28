using AudioInsight.Domain;
using AudioInsight.Infrastructure.Repositories;
using MongoDB.Driver;

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

    public async Task<bool> IsCategoryExists(string title)
    {
        var filter = Builders<Category>.Filter.Eq(c => c.Title, title);
        var exists = await _context.Categories
            .Find(filter)
            .Limit(1)
            .AnyAsync();

        return exists;
    }
}
