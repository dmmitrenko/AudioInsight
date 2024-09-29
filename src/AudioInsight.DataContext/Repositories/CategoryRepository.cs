using AudioInsight.Domain.Model;
using AudioInsight.Infrastructure.Repositories;
using MongoDB.Driver;

namespace AudioInsight.DataContext.Repositories;

public class CategoryRepository(MongoDbContext context) : Repository<Category>(context, nameof(context.Categories)), ICategoryRepository
{
}
