
using AIToolFinder.Dtos.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AIToolFinder.Services.Reviews;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _context;

    public ReviewService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Review>> GetAllReviews(ReviewFilterRequest reviewFilter)
    {
        List<Review> allReviews = await _context.Reviews.ToListAsync();
        
        if (reviewFilter.ToolId != null)
            allReviews = allReviews.Where(review => review.ToolId == reviewFilter.ToolId).ToList();

        if (reviewFilter.Rating != null) 
            allReviews = allReviews.Where(review => review.Rating >= reviewFilter.Rating).ToList();
        
        if (reviewFilter.Status != null)
            allReviews = allReviews.Where(review => review.Status == reviewFilter.Status).ToList();
        
        return allReviews;
    }

    public async Task<Review?> SubmitReview(CreateReviewRequest request)
    {
        var review = new Review
        {
            ToolId = request.ToolId,
            Rating = request.Rating,
            Comment = request.Comment,
            Status = ApprovalStatus.Pending
        };

        AiTool? tool = await _context.AiTools.FindAsync(request.ToolId);
        if (tool == null) return null;

        EntityEntry<Review> result = await _context.Reviews.AddAsync(review);
        _context.SaveChanges();
        return result.Entity;
    }
}
