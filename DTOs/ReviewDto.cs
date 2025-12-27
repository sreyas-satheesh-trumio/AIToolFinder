using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

public class ReviewDto
{
    [Required]
    public Guid ToolId { get; set; }

    [Required]
    public int Rating { get; set; }
    public string? Comment { get; set; }
}