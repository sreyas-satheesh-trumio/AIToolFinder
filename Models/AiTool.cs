using AIToolFinder.Enums;

public class AiTool
{
    public int Id { get; set; }
    public string ToolName { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string UseCase { get; set; } = null!;
    public PricingModel PricingType { get; set; }
    public double AverageRating { get; set; }
    public bool IsDeleted { get; set; } = false;
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
