using AIToolFinder.Dtos.Reviews;

namespace AIToolFinder.Services.Reviews;

public interface IReviewService
{
    Task<Review?> CreateAsync(CreateReviewRequest review);
    Task<List<Review>> GetAllAsync(ReviewFilterRequest reviewFilter);
    Task<Review?> GetAsync(int id);
    Task<Review?> UpdateAsync(int id, UpdateReviewRequest updateData);
}
