using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Database;

public class ApplicationContext
{
    public readonly IMongoDatabase Database;

    public ApplicationContext(IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("MongoDb");
        var connection = new MongoUrlBuilder(connectionString);
        MongoClient client = new MongoClient(connectionString);
        Database = client.GetDatabase(connection.DatabaseName);
    }
}