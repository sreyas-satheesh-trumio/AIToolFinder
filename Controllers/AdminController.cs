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

    // POST /admin/tools
    [HttpPost("tools")]
    public IActionResult AddTool(AITool tool)
    {
        _adminService.AddTool(tool);
        return Ok("Tool added");
    }

    // DELETE /admin/tools/{id}
    [HttpDelete("tools/{id}")]
    public IActionResult DeleteTool(int id)
    {
        _adminService.DeleteTool(id);
        return Ok("Tool deleted");
    }

    // POST /admin/reviews/{id}/approve
    [HttpPost("reviews/{id}/approve")]
    public IActionResult ApproveReview(int id)
    {
        _adminService.ApproveReview(id);
        return Ok("Review approved");
    }

    // POST /admin/reviews/{id}/reject
    [HttpPost("reviews/{id}/reject")]
    public IActionResult RejectReview(int id)
    {
        _adminService.RejectReview(id);
        return Ok("Review rejected");
    }
}
