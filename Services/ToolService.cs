using Microsoft.EntityFrameworkCore;

<<<<<<< HEAD
public class ToolService : IToolService
=======
using AIToolFinder.Dtos;
using AIToolFinder.Services;

public class ToolService
>>>>>>> 659620d64d4df64bac45d7c6aa23e96971a28c87
{
    private readonly AIToolDbContext _dbContext;

    public ToolService(AIToolDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<AITool> GetTools(FilterToolsDto? filter)
    {
        var query = _dbContext.AITools.AsQueryable();

        if (filter != null)
        {
            if (!string.IsNullOrWhiteSpace(filter.Category))
                query = query.Where(t => t.Category == filter.Category);

            if (filter.PricingType != null)
                query = query.Where(t => t.PricingType == filter.PricingType);

            if (filter.Rating > 0)
                query = query.Where(t => t.AverageRating >= filter.Rating);

            if (!string.IsNullOrEmpty(filter.UseCase))
                query = query.Where(t => t.UseCase != null &&
                                         t.UseCase.Contains(filter.UseCase));
        }

        return query.ToList();
    }

    public bool RecalculateRating(int toolId)
    {
<<<<<<< HEAD
        try
        {
            var tool = _dbContext.AITools
                .Include(t => t.Reviews)
                .FirstOrDefault(t => t.Id == toolId);
=======
        var tools = _toolRepo.Read();
        var reviews = _reviewRepo.Read()
            .Where(r => r.ToolId == toolId && r.Status == ApprovalStatus.Approved)
            .ToList();
>>>>>>> 659620d64d4df64bac45d7c6aa23e96971a28c87

            if (tool == null)
                return false;

            var approvedReviews = tool.Reviews?
                .Where(r => r.Status == "Approved")
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
