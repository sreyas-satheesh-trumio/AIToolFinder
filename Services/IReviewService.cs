namespace AITOOLFINDER.Services
{
    public interface IReviewService
    {
        Review SubmitReview(ReviewDto reviewDto);

        IEnumerable<Review> GetReviewsForTool(Guid toolId);

        Review SetApprovalStatus(int reviewId, ReviewStatus status);
    }
}
