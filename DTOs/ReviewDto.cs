using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

public class ReviewDto
{
    [Required(ErrorMessage = "ToolId is required")]
    public Guid ToolId { get; set; }

    [Required(ErrorMessage = "Rating is required")]
    public int Rating { get; set; }
    public string? Comment { get; set; }
}