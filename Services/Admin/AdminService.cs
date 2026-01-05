using AIToolFinder.Enums;
using AIToolFinder.Services.Tools;

namespace AIToolFinder.Services.Admin;

public class AdminService : IAdminService
{
    private readonly AppDbContext _db;
    private readonly IToolService _toolService;
    public AdminService(AppDbContext dbContext, IToolService toolService)
    {
        _db = dbContext;
        _toolService = toolService;
    }

    public async Task<Review?> ApproveReviewAsync(int id)
    {
        Review? review = await _db.Reviews.FindAsync(id);
        if (review == null) return null;
        review.Status = ApprovalStatus.Approved;
        await _db.SaveChangesAsync();
        _toolService.RecalculateRating(id);
        return review;
    }

    public async Task<AITool> CreateAIToolAsync(CreateToolDto tool)
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

    public async Task<AITool?> DeleteAIToolAsync(int id)
    {
        AITool? toolToRemove = await _db.AiTools.FindAsync(id);

        if (toolToRemove == null)
            return null;

        _db.AiTools.Remove(toolToRemove);
        await _db.SaveChangesAsync();
        return toolToRemove;
    }

    public async Task<Review?> RejectReviewAsync(int id)
    {
        Review? review = await _db.Reviews.FindAsync(id);
        if (review == null) return null;
        review.Status = ApprovalStatus.Rejected;
        await _db.SaveChangesAsync();
        return review;
    }
}

