using AIToolFinder.Enums;

public class AITool
{
    public int Id { get; set; }
    public string ToolName { get; set; } = null!;
    public string Category { get; set; } = null!;
    public PricingModel PricingType { get; set; }
    public double AverageRating { get; set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
