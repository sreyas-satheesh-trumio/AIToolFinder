using System.ComponentModel.DataAnnotations;

public class CreateToolDto
{
    [Required(ErrorMessage = "ToolName is required")]
    public string ToolName { get; set; } = null!;

    [Required(ErrorMessage = "UseCase is required")]
    public string UseCase { get; set; } = null!;

    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = "Pricing is required")]
    public PricingType Pricing { get; set; }  
}
