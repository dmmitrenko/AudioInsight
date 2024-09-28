using AudioInsight.Domain;
using System.Linq.Expressions;

namespace AudioInsight.Infrastructure.Repositories;
public interface ICategoryRepository
{
    Task<Category> GetById(Guid id);

    Task<IEnumerable<Category>> GetAll();

    Task Add(Category category);

    Task Delete(Guid id);

    Task<Category> Update(Category category);

    Task<bool> IsCategoryExists(Expression<Func<Category, bool>> filter);
}
