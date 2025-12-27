using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NeonDb")));

var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.UseStaticFiles();
app.Run();
