using AIToolFinder.Dtos.Tools;
using AIToolFinder.Services;
using Microsoft.EntityFrameworkCore;

namespace AIToolFinder.Services.Tools;

public class ToolService : IToolService
{
    private readonly AppDbContext _dbContext;

    public ToolService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<AITool> GetTools(ToolFilterRequest? filter)
    {
        var query = _dbContext.AiTools.AsQueryable();

        if (filter != null)
        {
            if (!string.IsNullOrWhiteSpace(filter.Category))
                query = query.Where(t => t.Category == filter.Category);

            if (filter.PricingType != null)
                query = query.Where(t => t.PricingType == filter.PricingType);

            if (filter.Rating > 0)
                query = query.Where(t => t.AverageRating >= filter.Rating);

            if (!string.IsNullOrEmpty(filter.UseCase))
                query = query.Where(t => t.UseCase != null && t.UseCase.Contains(filter.UseCase));
        }

        return query.ToList();
    }

    public bool RecalculateRating(int toolId)
    {
        try
        {
            var tool = _dbContext.AiTools
                .Include(t => t.Reviews)
                .FirstOrDefault(t => t.Id == toolId);

            if (tool == null)
                return false;

            var approvedReviews = tool.Reviews?
                .Where(r => r.Status == ApprovalStatus.Approved)
                .ToList();

            tool.AverageRating = approvedReviews != null && approvedReviews.Any()
                ? approvedReviews.Average(r => r.Rating)
                : 0;

            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
