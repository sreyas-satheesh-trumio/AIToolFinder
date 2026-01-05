using AIToolFinder.Dtos.Admin;
using AIToolFinder.Dtos.Tools;
using AIToolFinder.Enums;
using AIToolFinder.Services.Tools;

namespace AIToolFinder.Services.Admin;

public class AdminReviewService : IAdminReviewService
{
    private readonly AppDbContext _db;
    private readonly IToolService _toolService;
    public AdminReviewService(AppDbContext dbContext, IToolService toolService)
    {
        _db = dbContext;
        _toolService = toolService;
    }

    public async Task<Review?> UpdateAsync(int id, UpdateReviewRequest updateData)
    {
        Review? review = await _db.Reviews.FindAsync(id);
        if (review == null) return null;
        review.Status = updateData.Status ?? review.Status;
        await _db.SaveChangesAsync();
        _toolService.RecalculateRating(id);
        return review;
    }
}


