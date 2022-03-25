namespace NotesServer.Configurations;

public class PresentationConfiguration
{
    private static string devPolicyKey = "devCorsPolicy";
    
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCors(options =>
        {
            options.AddPolicy(devPolicyKey, policy => {
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });
    }

    public static void ConfigureApplication(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(devPolicyKey);
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}