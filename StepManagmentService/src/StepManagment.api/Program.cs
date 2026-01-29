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
var connectionString = Environment.GetEnvironmentVariable("PostgreSqlConnection");


builder.Services.AddControllers();

builder.Services.AddJwtAuthentication();
// Register Repositories and Services for Steps
builder.Services.AddTransient<IStepService, StepService>();
builder.Services.AddScoped<IStepRepository, StepRepository>();


// Register Repositories and Services for Journeies
builder.Services.AddTransient<IDailyJourneyService, DailyJourneyService>();
builder.Services.AddScoped<IDailyJourneyRepository, DailyJourneyRepository>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


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
// custom middleware to restrict access based on criteria(api gateway)
app.UseMiddleware<RestrictAccessMiddleware>();

// Ensure auth order: Authentication then Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();