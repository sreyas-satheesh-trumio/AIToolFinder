using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly JsonFileService<Review> _reviewRepo = new("Data/reviews.json");
    private readonly ToolService _toolService = new();

    [HttpPost("review")]
    public IActionResult SubmitReview(Review review)
    {
        review.Id = Guid.NewGuid().GetHashCode();
        review.Status = "Pending";

        var reviews = _reviewRepo.Read();
        reviews.Add(review);
        _reviewRepo.Write(reviews);

        return Ok("Review submitted for approval");
          }
}