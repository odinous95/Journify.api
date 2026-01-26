using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ShareLib.SharedExtension;
using UserManagment.api.Middlewares;
using UserManagment.infrastructure.Data;
using UserManagment.infrastructure.Repository;
using UserManagment.service.Interfaces;
using UserManagment.service.usecases;


Env.Load();
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Add services to the container.
// Register Repositories and Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserServices>();
builder.Services.AddScoped<IJwtService, JwtService>();

// Add JWT Authentication extension method
builder.Services.AddJwtAuthentication();
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
app.UseMiddleware<ExceptionMiddleware>();

// Ensure auth order: Authentication then Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
