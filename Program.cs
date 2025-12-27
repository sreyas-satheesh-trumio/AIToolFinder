<<<<<<< HEAD
=======
using AIToolFinderApp.Services;
using Microsoft.EntityFrameworkCore;
>>>>>>> 68d0bd427624f72d646125d9e00190f484a6f3f2
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.UseStaticFiles();

app.Run();
