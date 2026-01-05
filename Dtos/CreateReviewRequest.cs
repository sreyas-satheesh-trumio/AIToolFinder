using System.ComponentModel.DataAnnotations;

public class CreateReviewRequest
{
    
    [Required(ErrorMessage = "Tool Id is required")]
    public int ToolId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}