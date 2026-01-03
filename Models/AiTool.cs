using AIToolFinder.Enums;

public class AITool
{
    public int Id { get; set; }
    public string ToolName { get; set; } = default!;
    public string UseCase { get; set; } = default!;
    public string Category { get; set; } = default!;
    public PricingModel PricingType { get; set; } = PricingModel.Free;
    public double AverageRating { get; set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
