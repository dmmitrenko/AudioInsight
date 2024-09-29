using System.Linq.Expressions;

namespace AudioInsight.Infrastructure.Repositories;

public interface IRepository<T> where T : class
{
    Task Add(T entity);

    Task Delete(Guid id);

    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(Guid id);

    Task<T> Update(T entity);

    Task<bool> IsEntityExists(Expression<Func<T, bool>> filter);
}
