using System.Reflection;
using Application.Validation;
using FluentValidation;
using MediatR;

namespace NotesServer.Configurations;

public class ApplicationConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(Assembly.Load("Application"));
        
        AssemblyScanner.FindValidatorsInAssembly(Assembly.Load("Application"))
            .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));
    }
}