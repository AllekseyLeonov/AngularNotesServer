using System.Reflection;
using Database;
using Domain.Interfaces;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ApplicationContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(Assembly.Load("Features"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("devCorsPolicy", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("devCorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();