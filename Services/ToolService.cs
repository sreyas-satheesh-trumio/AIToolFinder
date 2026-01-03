
using AIToolFinder.Dtos;
using AIToolFinder.Services;

public class ToolService
{
    private readonly JsonFileService<AITool> _toolRepo;
    private readonly JsonFileService<Review> _reviewRepo;

    public ToolService()
    {
        _toolRepo = new JsonFileService<AITool>("Data/tools.json");
        _reviewRepo = new JsonFileService<Review>("Data/reviews.json");
    }

    public List<AITool> GetTools(FilterToolsDto filter)
    {
        var tools = _toolRepo.Read();

        if (!string.IsNullOrEmpty(filter.Category))
            tools = tools.Where(t => t.Category == filter.Category).ToList();

        if (filter.PricingType != null)
            tools = tools.Where(t => t.PricingType == filter.PricingType).ToList();

        tools = tools.Where(t => t.AverageRating >= filter.Rating || t.AverageRating == 0).ToList();

        return tools;
    }

    public void RecalculateRating(int toolId)
    {
        var tools = _toolRepo.Read();
        var reviews = _reviewRepo.Read()
            .Where(r => r.ToolId == toolId && r.Status == ApprovalStatus.Approved)
            .ToList();

        var tool = tools.First(t => t.Id == toolId);
        tool.AverageRating = reviews.Any()
            ? reviews.Average(r => r.Rating)
            : 0;

        _toolRepo.Write(tools);
    }
}
