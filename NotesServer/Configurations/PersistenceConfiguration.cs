using Domain;
using Persistence;
using Persistence.Interfaces;

namespace NotesServer.Configurations;

public class PersistenceConfiguration
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IGenericRepository<Note>, GenericRepository<Note>>(options => 
            new GenericRepository<Note>(configuration.GetConnectionString("MongoDb")));
    }
}