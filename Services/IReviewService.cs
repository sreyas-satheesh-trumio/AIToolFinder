public interface IReviewService
{
    void SubmitReview(CreateReviewRequest  review);
    List<Review> GetAllReviews();
}
