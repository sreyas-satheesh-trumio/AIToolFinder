
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
        _reviewService.SubmitReview(request);
        return Ok("Review added");
    }
 
    // GET /reviews
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_reviewService.GetAllReviews());
    }
}
 
 