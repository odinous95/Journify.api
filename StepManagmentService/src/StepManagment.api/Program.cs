using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ShareLib.SharedExtension;
using ShareLib.SharedMiddlewares;
using StepManagment.api.Middlewares;
using StepManagment.infrastructure.Data;
using StepManagment.infrastructure.Repository;
using StepManagment.service.Interfaces;
using StepManagment.service.usecases;


Env.Load();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.

// Add Dev Database                   
var connectionString = Environment.GetEnvironmentVariable("PostgreSqlConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


// Register Repositories and Services for Steps
builder.Services.AddScoped<IStepRepository, StepRepository>();
builder.Services.AddTransient<IStepService, StepService>();


// Register Repositories and Services for Journeies
builder.Services.AddScoped<IDailyJourneyRepository, DailyJourneyRepository>();
builder.Services.AddTransient<IDailyJourneyService, DailyJourneyService>();



// Add authentication service
builder.Services.AddJwtAuthentication();
// Register Swagger generator (required for ISwaggerProvider)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// middlewares 
// global exception handling middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
// authentication & authorization middlewares
app.UseAuthorization();
// custom middleware to restrict access based on criteria(api gateway)
app.UseMiddleware<RestrictAccessMiddleware>();

app.MapControllers();

app.Run();