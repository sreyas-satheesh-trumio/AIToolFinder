using System.ComponentModel.DataAnnotations;

namespace AIToolFinder.Dtos.Reviews;

public class CreateReviewRequest
{
    
    [Required(ErrorMessage = "Tool Id is required")]
    public int ToolId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}