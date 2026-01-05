using AIToolFinder.Services;

namespace AIToolFinder.Dtos;

public class ReviewResponseDto
{
    public int Id { get; set; }
    public int ToolId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public ApprovalStatus? Status { get; set; }
}