using AIToolFinderApp.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.UseStaticFiles();

app.Run();
