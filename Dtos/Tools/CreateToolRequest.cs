using System.ComponentModel.DataAnnotations;
using AIToolFinder.Enums;

namespace AIToolFinder.Dtos.Tools;

public class CreateToolRequest
{
    [Required(ErrorMessage = "Tool Name is required")]
    public string ToolName { get; set; } = string.Empty;

    public string UseCase { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public PricingModel PricingType { get; set; } = PricingModel.Free;
}
