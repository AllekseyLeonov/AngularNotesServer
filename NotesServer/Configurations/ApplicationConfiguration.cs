using System.Reflection;
using MediatR;

namespace NotesServer.Configurations;

public class ApplicationConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(Assembly.Load("Application"));
    }
}