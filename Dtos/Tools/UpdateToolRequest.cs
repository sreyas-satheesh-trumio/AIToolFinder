using System.ComponentModel.DataAnnotations;
using AIToolFinder.Enums;

namespace AIToolFinder.Dtos.Tools;

public class UpdateToolRequest
{
    public string? ToolName { get; set; }

    public string? UseCase { get; set; }

    public string? Category { get; set; }

    public PricingModel? PricingType { get; set; }
}
