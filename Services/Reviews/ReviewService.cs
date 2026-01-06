
using AIToolFinder.Dtos.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AIToolFinder.Services.Reviews;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _dbContext;

    public ReviewService(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Review>> GetAllReviews(ReviewFilterRequest reviewFilter)
    {
        List<Review> allReviews = await _dbContext.Reviews.ToListAsync();
        
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

        AiTool? tool = await _dbContext.AiTools.FindAsync(request.ToolId);
        if (tool == null) return null;

        EntityEntry<Review> result = await _dbContext.Reviews.AddAsync(review);
        _dbContext.SaveChanges();
        return result.Entity;
    }
    
    public async Task<Review?> GetOne(int id)
    {
        return await _dbContext.Reviews.FindAsync(id);
    }

}
