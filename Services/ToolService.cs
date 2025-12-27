namespace AIToolFinderApp.Services
{
    public class ToolService : IToolService
    {
        public Task<AITool> AddToolAsync(CreateToolDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<AITool> DeleteToolAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AITool>> GetAllToolsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AITool> GetToolByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AITool> UpdateToolAsync(int id, AITool dto)
        {
            throw new NotImplementedException();
        }
    }
}