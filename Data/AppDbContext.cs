using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<AiTool> AiTools => Set<AiTool>();
    public DbSet<Review> Reviews => Set<Review>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AiTool>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.ToolName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.UseCase)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.PricingType)
            .IsRequired();

            entity.Property(e => e.PricingType)
                .IsRequired()
                .HasConversion<int>();

            entity.Property(e => e.AverageRating)
                .HasPrecision(3, 2)
                .HasDefaultValue(0);
        });


        modelBuilder.Entity<Review>(entity =>
       {
           entity.HasKey(r => r.Id);

           entity.HasOne(r => r.AiTool)
               .WithMany(t => t.Reviews)
               .HasForeignKey(r => r.ToolId)
               .OnDelete(DeleteBehavior.Cascade);

           entity.Property(r => r.ToolId)
               .IsRequired();

           entity.Property(r => r.Rating)
               .IsRequired();

           entity.ToTable(t =>
               t.HasCheckConstraint(
                   "CK_Review_Rating",
                   "[Rating] >= 1 AND [Rating] <= 5"
               ));

           entity.Property(r => r.Comment)
               .HasMaxLength(500);

           entity.Property(r => r.Status)
               .HasConversion<int>()
               .IsRequired();
       });
    }


}
