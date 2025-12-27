<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
=======
var builder = WebApplication.CreateBuilder(args);

>>>>>>> 6c2770182bf1c72ef9568e17c04b1dfb3279320a
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
