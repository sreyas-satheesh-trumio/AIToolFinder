
using AIToolFinder.Dtos;
using AIToolFinder.Dtos.Reviews;
using AIToolFinder.Services.Reviews;
using Microsoft.AspNetCore.Mvc;
 
[ApiController]
[Route("reviews")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;
 
    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
 
    [HttpGet]
    public async Task<ActionResult<List<Review>>> GetAllReviews()
    {
        List<Review> reviews = await _reviewService.GetAllReviews();
        return Ok(reviews);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview(CreateReviewRequest request)
    {
        Review? newReview = await _reviewService.SubmitReview(request);
        if (newReview == null)
            return NotFound("AI Tool not found for the given ToolId");

        return Ok(new
        {
            message = "Review added successfully",
            review = new ReviewResponse
            {
                Id = newReview.Id,
                ToolId = newReview.ToolId,
                Rating = newReview.Rating,
                Comment = newReview.Comment,
                Status = newReview.Status
            }
        });
    }
 
}
 
 
