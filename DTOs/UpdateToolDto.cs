using System.ComponentModel.DataAnnotations;

public class UpdateToolDto
{
    public string? ToolName { get; set; }
    public string? UseCase { get; set; }
    public string? Category { get; set; }
    public PricingType? Pricing { get; set; }
}