using AIToolFinder.Enums;

public class ToolResponse
{
    public int Id { get; set; }
    public string? ToolName { get; set; }
    public string? Category { get; set; }
    public string? UseCase { get; set; }
    public PricingModel? PricingType { get; set; }
    public double AverageRating { get; set; }
}
