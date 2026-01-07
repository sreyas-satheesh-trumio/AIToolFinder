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
    public async Task<ActionResult<List<ToolResponse>>> GetAllTools([FromQuery] ToolFilterRequest filter)
    {
        List<AiTool> tools = await _toolService.GetAllAsync(filter);
        return Ok(tools.Select(tool => new ToolResponse
        {
            Id = tool.Id,
            ToolName = tool.ToolName,
            Category = tool.Category,
            UseCase = tool.UseCase,
            PricingType = tool.PricingType,
            AverageRating = tool.AverageRating
        }));
    }
}
