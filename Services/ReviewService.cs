public class ReviewService : IReviewService
{
    private readonly JsonFileService<Review> _reviewRepo;

    public ReviewService()
    {
        _reviewRepo = new JsonFileService<Review>("Data/reviews.json");
    }

    public void SubmitReview(CreateReviewRequest request)
    {
        var review = new Review
        {
            Id = Guid.NewGuid().GetHashCode(),
            ToolId = request.ToolId,
            Rating = request.Rating,
            Comment = request.Comment,
            Status = "Pending"
        };

        var reviews = _reviewRepo.Read();
        reviews.Add(review);
        _reviewRepo.Write(reviews);
    }

    public List<Review> GetAllReviews()
    {
        return _reviewRepo.Read();
    }
}
