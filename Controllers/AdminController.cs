
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("admin")]
public class AdminController : ControllerBase
{
    // Repository to read and write AI tools from JSON file
    private readonly JsonFileService<AITool> _toolRepo = new("Data/tools.json");

    // Repository to read and write reviews from JSON file
    private readonly JsonFileService<Review> _reviewRepo = new("Data/reviews.json");

    private readonly ToolService _toolService = new();


    // POST: admin/tool
    // Adds a new AI tool to the system
    [HttpPost("tool")]
    public IActionResult AddTool(AITool tool)
    {
        // Read existing tools from JSON file
        var tools = _toolRepo.Read();

        // Generate a new ID for the tool
        tool.Id = tools.Count + 1;

        // Add the new tool to the list
        tools.Add(tool);

        // Save updated tool list back to JSON file
        _toolRepo.Write(tools);

        // Return success response
        return Ok("Tool added");
    }


    // DELETE: admin/tool/{id}
    // Deletes an AI tool using its ID
    [HttpDelete("tool/{id}")]
    public IActionResult DeleteTool(int id)
    {
        // Read existing tools from JSON file
        var tools = _toolRepo.Read();

        // Remove the tool that matches the given ID
        tools.RemoveAll(t => t.Id == id);

        // Save updated list back to JSON file
        _toolRepo.Write(tools);

        // Return success response
        return Ok("Tool deleted");
    }


    // POST: admin/review/{id}/approve
    // Approves a pending user review
    [HttpPost("review/{id}/approve")]
    public IActionResult ApproveReview(int id)
    {
        // Read all reviews from JSON file
        var reviews = _reviewRepo.Read();

        // Find the review using review ID
        var review = reviews.First(r => r.Id == id);

        // Update review status to Approved
        review.Status = "Approved";

        // Save updated reviews back to JSON file
        _reviewRepo.Write(reviews);

        // Recalculate the average rating for the related tool
        _toolService.RecalculateRating(review.ToolId);

        // Return success response
        return Ok("Review approved");
    }
}
