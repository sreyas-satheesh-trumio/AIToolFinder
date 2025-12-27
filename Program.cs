var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// 🔹 Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AI Tool Finder API v1");
    c.RoutePrefix = string.Empty; // Swagger UI will be at root: http://localhost:5000
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
