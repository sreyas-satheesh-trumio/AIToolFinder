using AIToolFinderApp.Models;
using AIToolFinderApp.Services;
using AIToolFinderApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AIToolFinderApp.Controllers
{
    [ApiController]
    [Route("api/tools")]
    public class ToolsController : ControllerBase
    {
        private readonly IToolService _toolService;

        public ToolsController(IToolService toolService)
        {
            _toolService = toolService;
        }

     
        [HttpPost]
        public async Task<IActionResult> AddTool([FromBody] CreateToolDto dto)
        {
            var tool = await _toolService.AddToolAsync(dto);
            return CreatedAtAction(nameof(GetToolById), new { id = tool.Id }, tool);
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAllTools()
        {
            var tools = await _toolService.GetAllToolsAsync();
            return Ok(tools);
        }

        // READ BY ID
        // GET: api/tools/{id}
        [HttpGet("{id}")]
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

        // UPDATE
        // PUT: api/tools/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTool(int id, [FromBody] AITool dto)
        {
            try
            {
                var updatedTool = await _toolService.UpdateToolAsync(id, dto);
                return Ok(updatedTool);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE
        // DELETE: api/tools/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTool(int id)
        {
            try
            {
                var deletedTool = await _toolService.DeleteToolAsync(id);
                return Ok(deletedTool);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
