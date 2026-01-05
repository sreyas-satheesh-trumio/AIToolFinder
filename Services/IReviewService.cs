public interface IReviewService
{
    Review SubmitReview(CreateReviewRequest  review);
    List<Review> GetAllReviews();
}
