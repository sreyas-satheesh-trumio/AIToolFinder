using AIToolFinder.Dtos.Tools;

namespace AIToolFinder.Services.Admin;

public interface IAdminToolService
{
    Task<AITool> CreateAsync(CreateToolRequest tool);
    Task<AITool?> DeleteAsync(int id);
}
