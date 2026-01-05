using AIToolFinder.Dtos.Tools;
using AIToolFinder.Services.Tools;
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
    public IActionResult GetAllTools([FromQuery] ToolFilterRequest filter)
    {
        return Ok(_toolService.GetTools(filter));
    }
}
