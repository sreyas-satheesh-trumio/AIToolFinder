using System.Text.Json.Serialization;
using AIToolFinder.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ToolService>();
builder.Services
    .AddSingleton<IJsonFileService<AITool>, JsonFileService<AITool>>((provider) => 
        new JsonFileService<AITool>("Data/tools.json"));
builder.Services
    .AddSingleton<IJsonFileService<Review>, JsonFileService<Review>>((provider) => 
        new JsonFileService<Review>("Data/reviews.json"));

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
