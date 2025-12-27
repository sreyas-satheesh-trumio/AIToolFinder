namespace AIToolFinderApp.Services
{
    public class ToolService : IToolService
    {
        private readonly JsonFileService<AITool> _jsonService;

        public ToolService(IWebHostEnvironment env)
        {
            var path = Path.Combine(env.WebRootPath, "data", "tools.json");
            _jsonService = new JsonFileService<AITool>(path);
        }

        // CREATE
        public async Task<AITool> AddToolAsync(CreateToolDto dto)
        {
            var tools = await _jsonService.ReadAsync();

            var newTool = new AITool
            {
                Id = tools.Any() ? tools.Max(t => t.Id) + 1 : 1,
                ToolName = dto.ToolName,
                UseCase = dto.UseCase,
                Category = dto.Category,
                PricingType = dto.Pricing,
                AverageRating = 0,
                CreatedAt = DateTime.UtcNow
            };

            tools.Add(newTool);
            await _jsonService.WriteAsync(tools);

            return newTool;
        }

        // READ ALL
        public async Task<IEnumerable<AITool>> GetAllToolsAsync()
        {
            return await _jsonService.ReadAsync();
        }

        // READ BY ID
        public async Task<AITool> GetToolByIdAsync(int id)
        {
            var tools = await _jsonService.ReadAsync();
            var tool = tools.FirstOrDefault(t => t.Id == id);

            if (tool == null)
                throw new KeyNotFoundException($"Tool with ID {id} not found.");

            return tool;
        }

        // UPDATE
        public async Task<AITool> UpdateToolAsync(int id, AITool dto)
        {
            var tools = await _jsonService.ReadAsync();
            var tool = tools.FirstOrDefault(t => t.Id == id);

            if (tool == null)
                throw new KeyNotFoundException($"Tool with ID {id} not found.");

            tool.ToolName = dto.ToolName;
            tool.UseCase = dto.UseCase;
            tool.Category = dto.Category;
            tool.PricingType = dto.PricingType;

            await _jsonService.WriteAsync(tools);
            return tool;
        }

        // DELETE
        public async Task<AITool> DeleteToolAsync(int id)
        {
            var tools = await _jsonService.ReadAsync();
            var tool = tools.FirstOrDefault(t => t.Id == id);

            if (tool == null)
                throw new KeyNotFoundException($"Tool with ID {id} not found.");

            tools.Remove(tool);
            await _jsonService.WriteAsync(tools);

            return tool;
        }
    }
}
