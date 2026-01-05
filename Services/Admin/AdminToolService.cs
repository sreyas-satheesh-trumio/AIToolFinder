using AIToolFinder.Dtos.Tools;
using AIToolFinder.Enums;
using AIToolFinder.Services.Tools;

namespace AIToolFinder.Services.Admin;

public class AdminToolService : IAdminToolService
{
    private readonly AppDbContext _db;
    public AdminToolService(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<AITool> CreateAsync(CreateToolRequest tool)
    {
        AITool newTool = new AITool
        {
            ToolName = tool.ToolName,
            UseCase = tool.UseCase,
            Category = tool.Category,
            PricingType = tool.PricingType ?? PricingModel.Free,
            AverageRating = 0
        };

        _db.AiTools.Add(newTool);
        await _db.SaveChangesAsync();
        return newTool;
    }

    public async Task<AITool?> DeleteAsync(int id)
    {
        AITool? toolToRemove = await _db.AiTools.FindAsync(id);

        if (toolToRemove == null)
            return null;

        _db.AiTools.Remove(toolToRemove);
        await _db.SaveChangesAsync();
        return toolToRemove;
    }
}

