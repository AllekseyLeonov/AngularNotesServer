using Domain.Core;
using MongoDB.Driver;

namespace Database;

public class ApplicationContext
{
    public readonly IMongoDatabase Database;

    public ApplicationContext()
    {
        string connectionString = "mongodb://localhost:27017/notes";
        var connection = new MongoUrlBuilder(connectionString);
        MongoClient client = new MongoClient(connectionString);
        Database = client.GetDatabase(connection.DatabaseName);
    }
}