using AIToolFinder.Services;

public class Review
{
    public int Id { get; set; }
    public int ToolId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public ApprovalStatus? Status { get; set; } = ApprovalStatus.Pending;
    public bool IsDeleted { get; set; } = false;
    public AiTool AiTool { get; set; } = null!;
}
