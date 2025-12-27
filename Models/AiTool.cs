public class AITool
{
    public int Id { get; set; }

    public string ToolName { get; set; }
    public string UseCase { get; set; }
    public string Category { get; set; }

    public PricingType PricingType { get; set; }

    public double AverageRating { get; set; } = 0;

  
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Review> Reviews { get; set; } = new();
}
