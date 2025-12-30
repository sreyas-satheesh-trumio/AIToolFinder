public class AdminService : IAdminService
{
    private readonly JsonFileService<AITool> _toolRepo;
    private readonly JsonFileService<Review> _reviewRepo;
    private readonly ToolService _toolService;

    public AdminService()
    {
        _toolRepo = new JsonFileService<AITool>("Data/tools.json");
        _reviewRepo = new JsonFileService<Review>("Data/reviews.json");
        _toolService = new ToolService();
    }

    public void AddTool(AITool tool)
    {
        var tools = _toolRepo.Read();
        tool.Id = tools.Count + 1;
        tools.Add(tool);
        _toolRepo.Write(tools);
    }

    public void DeleteTool(int id)
    {
        var tools = _toolRepo.Read();
        tools.RemoveAll(t => t.Id == id);
        _toolRepo.Write(tools);
    }

    public void ApproveReview(int reviewId)
    {
        var reviews = _reviewRepo.Read();
        var review = reviews.FirstOrDefault(r => r.Id == reviewId);

        if (review == null) return;

        review.Status = "Approved";
        _reviewRepo.Write(reviews);

        _toolService.RecalculateRating(review.ToolId);
    }

    public void RejectReview(int reviewId)
    {
        var reviews = _reviewRepo.Read();
        var review = reviews.FirstOrDefault(r => r.Id == reviewId);

        if (review == null) return;

        review.Status = "Rejected";
        _reviewRepo.Write(reviews);
    }
}
