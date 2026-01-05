using AIToolFinder.Dtos.Tools;

namespace AIToolFinder.Services.Admin;

public interface IAdminToolService
{
    Task<AiTool> CreateAsync(CreateToolRequest tool);
    Task<AiTool?> UpdateAsync(int id, UpdateToolRequest tool);
    Task<AiTool?> DeleteAsync(int id);
}
