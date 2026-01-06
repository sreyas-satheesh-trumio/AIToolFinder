
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
    public async Task<ActionResult<List<Review>>> GetAllReviews([FromQuery] ReviewFilterRequest reviewFilter)
    {
        List<Review> reviews = await _reviewService.GetAllAsync(reviewFilter);
        return Ok(reviews);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview(CreateReviewRequest request)
    {
        Review? newReview = await _reviewService.CreateAsync(request);
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

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
        Review? review = await _reviewService.GetAsync(id);

        if (review == null) return NotFound();
        return Ok(review);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Review>> UpdateReview(int id, UpdateReviewRequest updateData)
    {
        Review? updatedReview = await _reviewService.UpdateAsync(id, updateData);

        if (updatedReview == null)
            return NotFound();

        return Ok(new
        {
            Message = "Review Updated Successfully",
            Review = updatedReview
        });
    }
}
 
 
