<<<<<<< Updated upstream
var builder = WebApplication.CreateBuilder(args);

=======
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
>>>>>>> Stashed changes
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
