using AIToolFinder.Enums;

public class CreateToolDto
{
    public string ToolName { get; set; } = string.Empty;
    public string UseCase { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public PricingModel? PricingType { get; set; }
}
