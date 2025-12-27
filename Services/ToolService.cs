public class ToolService
{
    private readonly JsonFileService<AITool> _toolRepo;
    private readonly JsonFileService<Review> _reviewRepo;
 
    public ToolService()
    {
        _toolRepo = new JsonFileService<AITool>("Data/tools.json");
        _reviewRepo = new JsonFileService<Review>("Data/reviews.json");
    }
 
    public List<AITool> GetTools(string? category, string? price, double? minRating)
    {
        var tools = _toolRepo.Read();
 
        if (!string.IsNullOrEmpty(category))
            tools = tools.Where(t => t.Category == category).ToList();
 
        if (!string.IsNullOrEmpty(price))
            tools = tools.Where(t => t.PricingType == price).ToList();
 
        if (minRating.HasValue)
            tools = tools.Where(t => t.AverageRating >= minRating).ToList();
 
        return tools;
    }
 
    public void RecalculateRating(int toolId)
    {
        var tools = _toolRepo.Read();
        var reviews = _reviewRepo.Read()
            .Where(r => r.ToolId == toolId && r.Status == "Approved")
            .ToList();
 
        var tool = tools.First(t => t.Id == toolId);
        tool.AverageRating = reviews.Any()
            ? reviews.Average(r => r.Rating)
            : 0;
 
        _toolRepo.Write(tools);
    }
}
 