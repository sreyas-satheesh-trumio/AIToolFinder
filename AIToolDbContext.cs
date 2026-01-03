using Microsoft.EntityFrameworkCore;

public class AIToolDbContext : DbContext
{
    public AIToolDbContext(DbContextOptions<AIToolDbContext> options)
        : base(options) { }

    public DbSet<AITool> AITools { get; set; } = null!;
   // public DbSet<Review> Reviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}
