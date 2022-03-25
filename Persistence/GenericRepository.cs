using System.Linq.Expressions;
using Domain;
using MongoDB.Driver;
using Persistence.Interfaces;

namespace Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
{
    private readonly IMongoDatabase _context;

    public GenericRepository(string connectionString)
    {
        var connection = new MongoUrlBuilder(connectionString);
        MongoClient client = new MongoClient(connectionString);
        _context = client.GetDatabase(connection.DatabaseName);
    }
    
    public async Task<T> GetAsync(Guid id)
    {
        return (T) await _context.GetCollection<T>(typeof(T).ToString()).Find(doc => doc.Id == id.ToString()).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T t)
    {
        await _context.GetCollection<T>(typeof(T).ToString()).InsertOneAsync(t);
    }

    public async Task UpdateAsync(T t)
    {
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, t.Id);
        await _context.GetCollection<T>(typeof(T).ToString()).ReplaceOneAsync(filter, t);
    }

    public async Task DeleteAsync(T t)
    {
        await _context.GetCollection<T>(typeof(T).ToString()).DeleteOneAsync(doc => doc.Id == t.Id);
    }

    public async Task<IList<T>> GetAllAsync()
    {
        var filter = Builders<T>.Filter.Empty;
        return await _context.GetCollection<T>(typeof(T).ToString()).Find(filter).ToListAsync();
    }

    public async Task<IList<T>> FilterAsync(Expression<Func<T, bool>> predicate)
    {
        var collection = _context.GetCollection<T>(typeof(T).ToString());
        var filter = Builders<T>.Filter.Where(predicate);
        return await collection.Find(filter).ToListAsync();
    }
}