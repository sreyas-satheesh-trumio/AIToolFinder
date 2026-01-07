
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

    public async Task<List<Review>> GetAllAsync(ReviewFilterRequest reviewFilter)
    {
        List<Review> allReviews = await _dbContext.Reviews.Where(review => !review.IsDeleted).ToListAsync();
        
        if (reviewFilter.ToolId != null)
            allReviews = allReviews.Where(review => review.ToolId == reviewFilter.ToolId).ToList();

        if (reviewFilter.Rating != null) 
            allReviews = allReviews.Where(review => review.Rating >= reviewFilter.Rating).ToList();
        
        if (reviewFilter.Status != null)
            allReviews = allReviews.Where(review => review.Status == reviewFilter.Status).ToList();
        
        return allReviews;
    }

    public async Task<Review?> CreateAsync(CreateReviewRequest request)
    {
        AiTool? tool = await _dbContext.AiTools.FindAsync(request.ToolId);
        if (tool == null) return null;

        var review = new Review
        {
            ToolId = request.ToolId,
            Rating = request.Rating,
            Comment = request.Comment,
            Status = ApprovalStatus.Pending,
            IsDeleted = false
        };

        EntityEntry<Review> result = await _dbContext.Reviews.AddAsync(review);
        _dbContext.SaveChanges();
        return result.Entity;
    }
    
    public async Task<Review?> GetAsync(int id)
    {
        return await _dbContext.Reviews.FirstOrDefaultAsync(review => review.Id == id && !review.IsDeleted);
    }

    public async Task<Review?> UpdateAsync(int id, UpdateReviewRequest updateData)
    {
        Review? reviewToUpdate = await _dbContext.Reviews.FirstOrDefaultAsync(review => review.Id == id && !review.IsDeleted);

        if (reviewToUpdate == null) return null;

        if (updateData.Rating != null)
            reviewToUpdate.Rating = (int)updateData.Rating;
        
        if (updateData.Comment != null)
            reviewToUpdate.Comment = updateData.Comment;
        
        reviewToUpdate.Status = ApprovalStatus.Pending;

        await _dbContext.SaveChangesAsync();
        return reviewToUpdate;
    }

    public async Task<Review?> DeleteAsync(int id)
    {
        Review? reviewToDelete = await _dbContext.Reviews.FindAsync(id);

        if (reviewToDelete == null) return null;

        reviewToDelete.IsDeleted = true;
        await _dbContext.SaveChangesAsync();
        return reviewToDelete;
    }
}
