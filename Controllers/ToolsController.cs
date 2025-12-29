using AIToolFinder.Dtos;
using AIToolFinder.Enums;
using Microsoft.AspNetCore.Mvc;
    [ApiController]
    [Route("tools")]
    public class ToolsController : ControllerBase
    {
        private readonly ToolService _service = new();
    
        [HttpGet]
        public IActionResult GetTools([FromQuery] FilterToolsDto filter)
        {
            var result = _service.GetTools(filter);
            return Ok(result);
        }
    }
