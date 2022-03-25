using NotesServer.Configurations;

var builder = WebApplication.CreateBuilder(args);

PersistenceConfiguration.ConfigureServices(builder.Services, builder.Configuration);
ApplicationConfiguration.ConfigureServices(builder.Services);
PresentationConfiguration.ConfigureServices(builder.Services);

var app = builder.Build();

PresentationConfiguration.ConfigureApplication(app);

app.Run();