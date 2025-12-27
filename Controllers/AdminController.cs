using AIToolFinderApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIToolFinder.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IToolService _toolService;

        public AdminController(IToolService toolService)
        {
            _toolService = toolService;
        }

        // POST: api/admin/addtools
        [HttpPost("tool")]
        public IActionResult AddTool([FromBody] CreateToolDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTool = _toolService.AddToolAsync(dto);

            return Ok(new
            {
                Message = "AI tool added successfully",
                Tool = createdTool
            });
        }

        [HttpPut("tool/{id}")]
        public async Task<IActionResult> UpdateTool(int id, [FromBody] UpdateToolDto tool)
        {
            if (tool == null)
                return BadRequest("Cant update the data to NULL values.");

            var newTool = new AITool
            {
                Id = id,
                ToolName = tool.ToolName!,
                UseCase = tool.UseCase!,
                Category = tool.Category!,
                PricingType = tool.Pricing ?? PricingType.Free
            };

            try
            {
                var updatedTool = await _toolService.UpdateToolAsync(id, newTool);
                return Ok(updatedTool);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("tool/{id}")]
        public async Task<IActionResult> DeleteTool(int id)
        {
            try
            {
                var deletedTool = await _toolService.DeleteToolAsync(id);
                return Ok(new
                {
                    Message = "AI tool deleted successfully",
                    Tool = deletedTool
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("tool/{id}")]
        public async Task<IActionResult> GetToolById(int id)
        {
            try
            {
                var tool = await _toolService.GetToolByIdAsync(id);
                return Ok(tool);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
