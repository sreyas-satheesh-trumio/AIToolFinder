
using AIToolFinder.Services;

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
            Status = ApprovalStatus.Pending
        };

        _context.Reviews.Add(review);
        _context.SaveChanges();
    }

    public List<Review> GetAllReviews()
    {
        return _context.Reviews.ToList();
    }
    
}
