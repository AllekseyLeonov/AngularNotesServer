using System.Linq.Expressions;
using Domain.Core;

namespace Domain.Interfaces;

public interface IGenericRepository<T> where T : IEntity
{
    Task<T> GetAsync(int id);
    Task CreateAsync(T t);
    Task UpdateAsync(T t);
    Task DeleteAsync(T t);
    Task<IList<T>> GetAllAsync();
    Task<IList<T>> FilterAsync(Expression<Func<T, bool>> predicate);
}