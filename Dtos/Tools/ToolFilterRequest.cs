using AIToolFinder.Enums;

namespace AIToolFinder.Dtos.Tools;

public class ToolFilterRequest
{
    public string? Category { get; set; }
    public PricingModel? PricingType { get; set; }
    public double Rating { get; set; } = 0;
     public string? UseCase { get; set; }
}
