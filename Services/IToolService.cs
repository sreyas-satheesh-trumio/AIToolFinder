namespace AIToolFinderApp.Services
{
    public interface IToolService
    {
        Task<IEnumerable<AITool>> GetAllToolsAsync();
        Task<AITool> GetToolByIdAsync(int id);
        Task<AITool> AddToolAsync(CreateToolDto dto);
        Task<AITool> UpdateToolAsync(int id, AITool dto);
        Task<AITool> DeleteToolAsync(int id);
    }
}