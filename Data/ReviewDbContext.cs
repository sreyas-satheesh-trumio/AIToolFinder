using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public class ReviewDbContext : DbContext
{
    public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
        : base(options)
    {
    }

    public DbSet<Review> Reviews { get; set; }
    public DbSet<AITool> AITools { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<AITool>()
        .Property(t => t.PricingType)
        .HasConversion<int>();

    base.OnModelCreating(modelBuilder);
}

}
