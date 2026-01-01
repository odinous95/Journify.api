using Journify.api.Filters;
using Journify.infrastructure.Data;
using Journify.infrastructure.Repository;
using Journify.service.Interfaces;
using Journify.service.usecases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options => options.Filters.Add<GloblaExceptionFilter>()
    );
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Add In-Memory Database
builder.Services.AddInMemoryDb();
builder.Services.AddScoped<IStepRepository, StepRepository>();
builder.Services.AddTransient<IStepService, StepUsecase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
