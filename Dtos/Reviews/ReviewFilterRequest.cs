using AIToolFinder.Services;

namespace AIToolFinder.Dtos.Reviews;

public class ReviewFilterRequest {
    public int? ToolId { get; set; }
    public int? Rating { get; set; }
    public ApprovalStatus? Status { get; set; }
}