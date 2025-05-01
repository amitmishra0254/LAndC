using ATMMachine.Business.Interfaces;
using ATMMachine.Business.Managers;
using ATMMachine.DAL.Context;
using ATMMachine.DAL.Repositories;
using ATMMachine.DAL.Repositories.Interfaces;
using ATMMachine.Middlewares;
using ATMMachine.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddDbContext<ATMDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ATMDbConnectionString"));
});

builder.Services.AddScoped<AccountRepository, AccountRepositoryImp>();
builder.Services.AddScoped<UserRepository, UserRepositoryImp>();
builder.Services.AddScoped<ATMServices, ATMServicesImp>();

builder.Services.AddScoped<AccountManager, AccountManagerImp>();
builder.Services.AddScoped<UserManager, UserManagerImp>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ServerHealthCheckMiddleware>();

app.MapControllers();

app.Run();
