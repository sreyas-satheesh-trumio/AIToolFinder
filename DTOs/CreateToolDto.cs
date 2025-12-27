using System.ComponentModel.DataAnnotations;

public class CreateToolDto
{
    [Required]
    public string? ToolName { get; set; }

    [Required]
    public string? UseCase { get; set; }

    [Required]
    public string? Category { get; set; }

    [Required]
    public PricingType? Pricing { get; set; }
}