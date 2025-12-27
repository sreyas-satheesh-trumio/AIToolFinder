using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using 
=======

>>>>>>> 68d0bd427624f72d646125d9e00190f484a6f3f2
[ApiController]
[Route("api")] // base route matching lab example
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
<<<<<<< HEAD
 
=======

>>>>>>> 68d0bd427624f72d646125d9e00190f484a6f3f2
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
<<<<<<< HEAD
 
=======

>>>>>>> 68d0bd427624f72d646125d9e00190f484a6f3f2
    // POST /api/review - Submit a new review
    [HttpPost("review")]
    public IActionResult SubmitReview([FromBody] ReviewDto reviewDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
<<<<<<< HEAD
 
        var review = _reviewService.SubmitReview(reviewDto);
 
        if (review == null)
            return NotFound(new { message = "Tool not found" });
 
        return CreatedAtAction(nameof(GetReviewsForTool), new { toolId = review.ToolId }, review);
    }
 
=======

        var review = _reviewService.SubmitReview(reviewDto);

        if (review == null)
            return NotFound(new { message = "Tool not found" });

        return CreatedAtAction(nameof(GetReviewsForTool), new { toolId = review.ToolId }, review);
    }

>>>>>>> 68d0bd427624f72d646125d9e00190f484a6f3f2
    // GET /api/review/tool/{toolId} - Get all reviews for a tool
    [HttpGet("review/tool/{toolId}")]
    public IActionResult GetReviewsForTool(Guid toolId)
    {
        var reviews = _reviewService.GetReviewsForTool(toolId);
        if (reviews == null || !reviews.Any())
            return NotFound(new { message = "No reviews found for this tool" });
<<<<<<< HEAD
 
        return Ok(reviews);
    }
 
=======

        return Ok(reviews);
    }

>>>>>>> 68d0bd427624f72d646125d9e00190f484a6f3f2
[HttpPost("review/{reviewId}")]
public IActionResult ApproveReview(int reviewId, [FromBody] ReviewApprovalDto approvalDto)
{
    if (approvalDto == null || !ModelState.IsValid)
        return BadRequest(new { message = "Approval status is required and must be valid." });
<<<<<<< HEAD
 
    var review = _reviewService.SetApprovalStatus(reviewId, approvalDto.Status);
 
    if (review == null)
        return NotFound(new { message = "Review not found" });
 
   
    return Ok(review);
}
 
 
}
=======

    var review = _reviewService.SetApprovalStatus(reviewId, approvalDto.Status);

    if (review == null)
        return NotFound(new { message = "Review not found" });

    
    return Ok(review);
}


}
>>>>>>> 68d0bd427624f72d646125d9e00190f484a6f3f2
