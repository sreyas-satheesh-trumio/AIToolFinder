
using AIToolFinder.Dtos;
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
 
    // POST /reviews
    [HttpPost]
    public IActionResult Add(CreateReviewRequest request)
    {
        Review newReview = _reviewService.SubmitReview(request);
        return Ok(new
        {
            message = "Review added successfully",
            review = new ReviewResponseDto
            {
                Id = newReview.Id,
                ToolId = newReview.ToolId,
                Rating = newReview.Rating,
                Comment = newReview.Comment,
                Status = newReview.Status
            }
        });
    }
 
    // GET /reviews
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_reviewService.GetAllReviews());
    }
}
 
 
