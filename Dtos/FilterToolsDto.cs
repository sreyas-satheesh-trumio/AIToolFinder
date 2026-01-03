using System.ComponentModel.DataAnnotations;
using AIToolFinder.Enums;

namespace AIToolFinder.Dtos
{
    public class FilterToolsDto
    {
        public string? Category { get; set; }
        public PricingModel? PricingType { get; set; }

        [Range(1, 5, ErrorMessage = "Rating should be between 1 and 5")]
        public double Rating { get; set; } = 1;
    }
}