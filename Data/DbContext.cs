using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<AITool> AiTools => Set<AITool>();
    public DbSet<Review> Reviews => Set<Review>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AITool>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.ToolName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(t => t.UseCase)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(t => t.PricingType)
                .IsRequired()
                .HasConversion<int>();
            entity.Property(t => t.AverageRating)
                .HasDefaultValue(0);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Rating)
                .IsRequired();

            entity.Property(r => r.Comment)
                .HasMaxLength(1000);

            entity.Property(r => r.Status)
                .HasConversion<int>();

            entity.HasOne(r => r.AiTool)
                .WithMany(t => t.Reviews)
                .HasForeignKey(r => r.ToolId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
