using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ShareLib.SharedMiddlewares;
using UserManagment.api.Filters;
using UserManagment.infrastructure.Data;
using UserManagment.Infrastructure.Repository;
using UserManagment.service.Interfaces;
using UserManagment.service.usecases;


Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(
    options => options.Filters.Add<GloblaExceptionFilter>()
);
// Register Repositories and Services for Steps
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserServices>();

// Add Dev Database                   
var connectionString = Environment.GetEnvironmentVariable("PostgreSqlConnection");
// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Register Swagger generator (required for ISwaggerProvider)
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseAuthorization();
app.UseMiddleware<RestrictAccessMiddleware>();
app.MapControllers();

app.Run();
