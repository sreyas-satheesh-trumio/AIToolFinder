using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<AITool> AITools { get; set; }
    public DbSet<Review> Reviews { get; set; }
}
