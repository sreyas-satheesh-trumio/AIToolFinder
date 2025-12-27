using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("tools")]
public class ToolsController : ControllerBase
{
    private readonly ToolService _service = new();
 
    [HttpGet]
    public IActionResult GetTools(
        [FromQuery] string? category,
        [FromQuery] string? price,
        [FromQuery] double? rating)
    {
        var result = _service.GetTools(category, price, rating);
        return Ok(result);
    }
}
