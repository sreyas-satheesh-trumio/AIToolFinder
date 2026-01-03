<<<<<<< HEAD
<<<<<<< Updated upstream
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> rijo
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IAdminService, AdminService>();


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
