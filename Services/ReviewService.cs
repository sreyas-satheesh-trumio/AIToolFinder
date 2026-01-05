
using AIToolFinder.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _context;

    public ReviewService(AppDbContext context)
    {
        _context = context;
    }

    public Review SubmitReview(CreateReviewRequest request)
    {
        var review = new Review
        {
            ToolId = request.ToolId,
            Rating = request.Rating,
            Comment = request.Comment,
            Status = ApprovalStatus.Pending
        };

        EntityEntry<Review> result = _context.Reviews.Add(review);
        _context.SaveChanges();
        return result.Entity;
    }

    public List<Review> GetAllReviews()
    {
        return _context.Reviews.ToList();
    }
}
