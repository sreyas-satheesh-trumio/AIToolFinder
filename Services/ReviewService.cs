
public class ReviewService : IReviewService
{
    private readonly ReviewDbContext _context;

    public ReviewService(ReviewDbContext context)
    {
        _context = context;
    }

    public void SubmitReview(CreateReviewRequest request)
    {
        var review = new Review
        {
            ToolId = request.ToolId,
            Rating = request.Rating,
            Comment = request.Comment,
            Status = "Pending"
        };

        _context.Reviews.Add(review);
        _context.SaveChanges();

        UpdateToolAverageRating(request.ToolId);
    }

    public List<Review> GetAllReviews()
    {
        return _context.Reviews.ToList();
    }

    private void UpdateToolAverageRating(int toolId)
    {
        var approvedReviews = _context.Reviews
            .Where(r => r.ToolId == toolId && r.Status == "Approved")
            .ToList();

        if (!approvedReviews.Any())
            return;

        var avgRating = approvedReviews.Average(r => r.Rating);

        var tool = _context.AITools.FirstOrDefault(t => t.Id == toolId);
        if (tool != null)
        {
            tool.AverageRating = avgRating;
            _context.SaveChanges();
        }
    }
}
