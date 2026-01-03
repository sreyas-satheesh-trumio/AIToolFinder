using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<AITool> AITools { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;

    [Obsolete]
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure AITool entity
        modelBuilder.Entity<AITool>(entity =>
        {
            entity.HasKey(e => e.Id); // Primary key

            entity.Property(e => e.ToolName)
                .IsRequired()
                .HasMaxLength(100);        // Limit string length

            entity.Property(e => e.UseCase)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.PricingType)
            .IsRequired();
            entity.HasCheckConstraint("CK_AITool_PricingType", "[PricingType] IN (0, 1, 2)");

            entity.Property(e => e.AverageRating)
                .HasPrecision(3, 2)       // e.g., 4.75
                .HasDefaultValue(0);       // Default rating
        });


         modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(r => r.Id); // ReviewId is the primary key

            entity.Property(r => r.ToolId) 
                .IsRequired();

            entity.Property(r => r.Rating) //Rating should be between 1 and 5
                .IsRequired();
            entity.HasCheckConstraint(
                "CK_Review_Rating",
                "[Rating] >= 1 AND [Rating] <= 5"
            );

            entity.Property(r => r.Comment) //Optional
                .HasMaxLength(500);

            entity.Property(r => r.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue("Pending");

        });
    }


}
