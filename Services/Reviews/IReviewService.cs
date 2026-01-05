using AIToolFinder.Dtos.Reviews;

namespace AIToolFinder.Services.Reviews;

public interface IReviewService
{
    Task<Review?> SubmitReview(CreateReviewRequest  review);
    Task<List<Review>> GetAllReviews();
}
