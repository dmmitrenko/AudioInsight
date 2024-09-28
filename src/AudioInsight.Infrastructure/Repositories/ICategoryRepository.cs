using AudioInsight.Domain;

namespace AudioInsight.Infrastructure.Repositories;
public interface ICategoryRepository
{
    Task<Category> GetById(Guid id);

    Task<IEnumerable<Category>> GetAll();

    Task Add(Category category);

    Task Delete(Guid id);

    Task<bool> IsCategoryExists(string title);
}
