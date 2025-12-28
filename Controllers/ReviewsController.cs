using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly JsonFileService<Review> _reviewRepo = new("Data/reviews.json");
    private readonly ToolService _toolService = new();

    [HttpPost("review")]
    public IActionResult SubmitReview(Review review)
    {
        var reviews = _reviewRepo.Read();

        review.Id = reviews.Max(review => review.Id) + 1;
        review.Status = "Pending";

        reviews.Add(review);
        _reviewRepo.Write(reviews);
        _toolService.RecalculateRating(review.ToolId);

        return Ok("Review submitted for approval");
    }
}
