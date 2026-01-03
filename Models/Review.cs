public class Review
{
    public int Id { get; set; }
    public int ToolId { get; set; }
    public AITool AITool { get; set; } = null!;
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public string Status { get; set; } = "Pending";
}
