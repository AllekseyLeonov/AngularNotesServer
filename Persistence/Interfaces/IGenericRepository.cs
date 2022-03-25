using System.Linq.Expressions;
using Domain;

namespace Persistence.Interfaces;

public interface IGenericRepository<T> where T : IEntity
{
    Task<T> GetAsync(Guid id);
    Task CreateAsync(T t);
    Task UpdateAsync(T t);
    Task DeleteAsync(T t);
    Task<IList<T>> GetAllAsync();
    Task<IList<T>> FilterAsync(Expression<Func<T, bool>> predicate);
}