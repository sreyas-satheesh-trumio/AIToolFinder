
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
    public async Task<ActionResult<List<ReviewResponse>>> GetAllReviews([FromQuery] ReviewFilterRequest reviewFilter)
    {
        List<Review> reviews = await _reviewService.GetAllAsync(reviewFilter);
        return Ok(reviews.Select(review => new ReviewResponse
        {
            Id = review.Id,
            ToolId = review.ToolId,
            Rating = review.Rating,
            Comment = review.Comment,
            Status = review.Status
        }));
    }

    [HttpPost]
    public async Task<ActionResult<ReviewResponse>> CreateReview(CreateReviewRequest request)
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
    public async Task<ActionResult<ReviewResponse>> GetReview(int id)
    {
        Review? review = await _reviewService.GetAsync(id);

        if (review == null) return NotFound();
        return Ok(new ReviewResponse
        {
            Id = review.Id,
            ToolId = review.ToolId,
            Rating = review.Rating,
            Comment = review.Comment,
            Status = review.Status
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReviewResponse>> UpdateReview(int id, UpdateReviewRequest updateData)
    {
        Review? updatedReview = await _reviewService.UpdateAsync(id, updateData);

        if (updatedReview == null)
            return NotFound();

        return Ok(new
        {
            Message = "Review Updated Successfully",
            Review = new ReviewResponse 
            {
                Id = updatedReview.Id,
                ToolId = updatedReview.ToolId,
                Rating = updatedReview.Rating,
                Comment = updatedReview.Comment,
                Status = updatedReview.Status
            }
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ReviewResponse>> DeleteReview(int id)
    {
        Review? deletedReview = await _reviewService.DeleteAsync(id);

        if (deletedReview == null) return NotFound();

        return Ok(new
        {
            Message = "Review Deleted Successfully",
            Review = new ReviewResponse 
            {
                Id = deletedReview.Id,
                ToolId = deletedReview.ToolId,
                Rating = deletedReview.Rating,
                Comment = deletedReview.Comment,
                Status = deletedReview.Status
            }
        });
    }
}
 
 
