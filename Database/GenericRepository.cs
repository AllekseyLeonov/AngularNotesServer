using System.Linq.Expressions;
using Domain.Core;
using Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Database;

public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
{
    private readonly ApplicationContext _context;

    public GenericRepository(ApplicationContext context)
    {
        _context = context;
    }

    private bool filterFunction(int id1, int id2)
    {
        return id1 == id2;
    }
    public async Task<T> GetAsync(int id)
    {
        return (T) await _context.Database.GetCollection<T>(typeof(T).ToString()).Find(doc => doc.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T t)
    {
        await _context.Database.GetCollection<T>(typeof(T).ToString()).InsertOneAsync(t);
    }

    public async Task UpdateAsync(T t)
    {
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, t.Id);
        await _context.Database.GetCollection<T>(typeof(T).ToString()).ReplaceOneAsync(filter, t);
    }

    public async Task DeleteAsync(T t)
    {
        await _context.Database.GetCollection<T>(typeof(T).ToString()).DeleteOneAsync(doc => doc.Id == t.Id);
    }

    public async Task<IList<T>> GetAllAsync()
    {
        var filter = Builders<T>.Filter.Empty;
        return await _context.Database.GetCollection<T>(typeof(T).ToString()).Find(filter).ToListAsync();
    }

    public async Task<IList<T>> FilterAsync(Expression<Func<T, bool>> predicate)
    {
        var collection = _context.Database.GetCollection<T>(typeof(T).ToString());
        var filter = Builders<T>.Filter.Where(predicate);
        return await collection.Find(filter).ToListAsync();
    }
}