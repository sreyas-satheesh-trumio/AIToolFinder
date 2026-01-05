using AIToolFinder.Dtos.Tools;
using AIToolFinder.Enums;
using AIToolFinder.Services.Tools;

namespace AIToolFinder.Services.Admin;

public class AdminToolService : IAdminToolService
{
    private readonly AppDbContext _dbContext;
    public AdminToolService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AITool> CreateAsync(CreateToolRequest tool)
    {
        AITool newTool = new AITool
        {
            ToolName = tool.ToolName,
            UseCase = tool.UseCase,
            Category = tool.Category,
            PricingType = tool.PricingType,
            AverageRating = 0
        };

        _dbContext.AiTools.Add(newTool);
        await _dbContext.SaveChangesAsync();
        return newTool;
    }

    public async Task<AITool?> UpdateAsync(int id, UpdateToolRequest tool)
    {
        AITool? toolToUpdate = await _dbContext.AiTools.FindAsync(id);
        if (toolToUpdate == null)
            return null;

        toolToUpdate.ToolName = tool.ToolName ?? toolToUpdate.ToolName;
        toolToUpdate.UseCase = tool.UseCase ?? toolToUpdate.UseCase;
        toolToUpdate.Category = tool.Category ?? toolToUpdate.Category;
        toolToUpdate.PricingType = tool.PricingType ?? toolToUpdate.PricingType;

        await _dbContext.SaveChangesAsync();
        return toolToUpdate;
    }

    public async Task<AITool?> DeleteAsync(int id)
    {
        AITool? toolToRemove = await _dbContext.AiTools.FindAsync(id);

        if (toolToRemove == null)
            return null;

        _dbContext.AiTools.Remove(toolToRemove);
        await _dbContext.SaveChangesAsync();
        return toolToRemove;
    }

}

