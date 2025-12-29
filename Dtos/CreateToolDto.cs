using System.ComponentModel.DataAnnotations;
using AIToolFinder.Enums;

public class CreateToolDto
{
    [Required(ErrorMessage = "Tool name is required")]
    public string ToolName { get; set; } = default!;

    [Required(ErrorMessage = "Use case is required")]
    public string UseCase { get; set; } = default!;

    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; } = default!;

    public string PricingType { get; set; } = "Free";
}