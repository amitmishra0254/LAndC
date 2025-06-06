using Microsoft.EntityFrameworkCore;
using UserManagement.DAL;
using UserManagement.DAL.Repositories;
using UserManagement.Manager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));
builder.Services.AddScoped<UserRepository, UserRepositoryImp>();
builder.Services.AddScoped<UserManager, UserManagerImp>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
