
using AIToolFinder.Dtos;
using AIToolFinder.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("tool")]
    public async Task<ActionResult<AITool>> AddTool(CreateToolDto tool)
    {
        try
        {
            AITool newTool = await _adminService.CreateAIToolAsync(tool);
            return StatusCode(201, new
            {
                Message = "AI Tool Created Successfully",
                Tool = newTool
            });
        }
        catch(Exception ex)
        {
            return BadRequest($"Something went wrong ({ex.Message})");
        }
    }


    [HttpDelete("tool/{id}")]
    public async Task<ActionResult<AITool>> DeleteTool([FromRoute] int id)
    {
        try
        {
            AITool? deletedTool = await _adminService.DeleteAIToolAsync(id);
            if (deletedTool == null) return NotFound();
            return Ok(new
            {
                Message = "AI Tool Deleted Successfully",
                AITool = deletedTool
            });
        }
        catch(Exception ex)
        {
            return BadRequest($"Something went wrong ({ex.Message})");
        }
    }


    [HttpPut("review/{id}/approve")]
    public async Task<ActionResult<Review>> ApproveReview(int id)
    {
        try
        {
            Review? updatedReview = await _adminService.ApproveReviewAsync(id);
            if (updatedReview == null) return NotFound();
            return Ok(new
            {
                Message = "Review Approved Successfully",
                AITool = updatedReview
            });
        }
        catch(Exception ex)
        {
            return BadRequest($"Something went wrong ({ex.Message})");
        }
    }

    [HttpPut("review/{id}/reject")]
    public async Task<ActionResult<Review>> RejectReview(int id)
    {
        try
        {
            Review? updatedReview = await _adminService.RejectReviewAsync(id);
            if (updatedReview == null) return NotFound();
            return Ok(new
            {
                Message = "Review Rejected Successfully",
                AITool = updatedReview
            });
        }
        catch(Exception ex)
        {
            return BadRequest($"Something went wrong ({ex.Message})");
        }
    }
}
