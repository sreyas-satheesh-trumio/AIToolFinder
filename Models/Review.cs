public class Review
{
    public int Id { get; set; }

   
    public int ToolId { get; set; }
    public AITool Tool { get; set; }

    public int Rating { get; set; } 
    public string Comment { get; set; }

    public ReviewStatus Status { get; set; } = ReviewStatus.Pending;

  
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    
    public DateTime? UpdatedAt { get; set; }
}
