using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("tools")]
public class ToolsController : ControllerBase
{
    private readonly IToolService _toolService;

    public ToolsController(IToolService toolService)
    {
        _toolService = toolService;
    }

    [HttpGet]
    public IActionResult GetTools([FromQuery] FilterToolsDto filter)
    {
        return Ok(_toolService.GetTools(filter));
    }

    [HttpPost("{id}/recalculate-rating")]
    public IActionResult RecalculateRating(int id)
    {
        var success = _toolService.RecalculateRating(id);
        return success ? Ok("Rating updated") : NotFound("Tool not found");
    }
}
