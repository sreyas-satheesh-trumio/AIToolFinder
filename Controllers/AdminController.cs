using AIToolFinder.Dtos;
using AIToolFinder.Dtos.Tools;
using AIToolFinder.Services;
using AIToolFinder.Services.Admin;
using AIToolFinder.Dtos.Reviews;
using Microsoft.AspNetCore.Mvc;
using AIToolFinder.Dtos.Admin;

[ApiController]
[Route("admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminToolService _adminToolService;
    private readonly IAdminReviewService _adminReviewService;

    public AdminController(IAdminToolService adminToolService, IAdminReviewService adminReviewService)
    {
        _adminToolService = adminToolService;
        _adminReviewService = adminReviewService;
    }

    [HttpPost("tools")]
    public async Task<ActionResult<AiTool>> CreateTool(CreateToolRequest tool)
    {
        AiTool newTool = await _adminToolService.CreateAsync(tool);
        return StatusCode(201, new
        {
            Message = "AI Tool Created Successfully",
            Tool = newTool
        });
    }

    [HttpPut("tools/{id}")]
    public async Task<ActionResult<AiTool>> UpdateTool(int id, UpdateToolRequest tool)
    {
        AiTool? updatedTool = await _adminToolService.UpdateAsync(id, tool);

        if (updatedTool == null)
            return NotFound();

        return Ok(new
        {
            Message = "AI Tool Updated Successfully",
            Tool = updatedTool
        });
    }

    [HttpDelete("tools/{id}")]
    public async Task<ActionResult<AiTool>> DeleteTool(int id)
    {
        AiTool? deletedTool = await _adminToolService.DeleteAsync(id);

        if (deletedTool == null)
            return NotFound();

        return Ok(new
        {
            Message = "AI Tool Deleted Successfully",
            Tool = deletedTool
        });
    }

    [HttpPut("reviews/{id}/status")]
    public async Task<ActionResult<ReviewResponse>> UpdateReview(int id, [FromBody] UpdateApprovalStatusRequest updateData)
    {
        try
        {
            Review? updatedReview = await _adminReviewService.UpdateAsync(id, updateData);
            if (updatedReview == null) return NotFound();
            return Ok(new
            {
                Message = "Review Updated Successfully",
                AITool = new ReviewResponse
                {
                    Id = updatedReview.Id,
                    ToolId = updatedReview.ToolId,
                    Rating = updatedReview.Rating,
                    Comment = updatedReview.Comment,
                    Status = updatedReview.Status
                }
            });
        }
        catch (Exception ex)
        {
            return BadRequest($"Something went wrong ({ex.Message})");
        }
    }
}
