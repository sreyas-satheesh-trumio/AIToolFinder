using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")] // base route matching lab example
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    // POST /api/review - Submit a new review
    [HttpPost("review")]
    public IActionResult SubmitReview([FromBody] ReviewDto reviewDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = _reviewService.SubmitReview(reviewDto);

        if (review == null)
            return NotFound(new { message = "Tool not found" });

        return CreatedAtAction(nameof(GetReviewsForTool), new { toolId = review.ToolId }, review);
    }

    // GET /api/review/tool/{toolId} - Get all reviews for a tool
    [HttpGet("review/tool/{toolId}")]
    public IActionResult GetReviewsForTool(Guid toolId)
    {
        var reviews = _reviewService.GetReviewsForTool(toolId);
        if (reviews == null || !reviews.Any())
            return NotFound(new { message = "No reviews found for this tool" });

        return Ok(reviews);
    }

[HttpPost("review/{reviewId}")]
public IActionResult ApproveReview(int reviewId, [FromBody] ReviewApprovalDto approvalDto)
{
    if (approvalDto == null || !ModelState.IsValid)
        return BadRequest(new { message = "Approval status is required and must be valid." });

    var review = _reviewService.SetApprovalStatus(reviewId, approvalDto.Status);

    if (review == null)
        return NotFound(new { message = "Review not found" });

    
    return Ok(review);
}


}
