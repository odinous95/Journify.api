using Journify.api.Filters;
using Journify.infrastructure.Data;
using Journify.infrastructure.Repository;
using Journify.service.Interfaces;
using Journify.service.usecases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options => options.Filters.Add<GloblaExceptionFilter>()
    );
// Add Dev Database                   
var connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


// Register Repositories and Services for Steps
builder.Services.AddScoped<IStepRepository, StepRepository>();
builder.Services.AddTransient<IStepService, StepService>();

// Register Repositories and Services for Users
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

// Register Repositories and Services for Journeies
builder.Services.AddScoped<IDailyJourneyRepository, DailyJourneyRepository>();
builder.Services.AddTransient<IDailyJourneyService, DailyJourneyService>();

// Register Swagger generator (required for ISwaggerProvider)
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

app.MapControllers();

app.Run();
