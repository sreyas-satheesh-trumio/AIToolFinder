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

    public List<AiTool> GetTools(ToolFilterRequest? filter)
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
            AiTool? tool = _dbContext.AiTools.Find(toolId);

            if (tool == null) return true;

            List<Review> reviews = _dbContext.Reviews.Where(review => 
                    review.Status == ApprovalStatus.Approved && 
                    review.ToolId == toolId && 
                    !review.IsDeleted
                ).ToList();

            if (!reviews.Any()) return true;

            double avg = reviews.Average(review => review.Rating);
            tool.AverageRating = avg;
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
