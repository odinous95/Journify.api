using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotApiGateway.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
var app = builder.Build();


app.MapGet("/", () => "Hello World from Ocelot Api gateway!");
app.MapControllers();
app.UseMiddleware<InterceptMiddleware>();
await app.UseOcelot();

app.Run();
