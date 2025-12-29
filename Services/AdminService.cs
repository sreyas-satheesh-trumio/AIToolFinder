namespace AIToolFinder.Services
{
    public class AdminService : IAdminService
    {
        private readonly ToolService _toolService;
        private readonly IJsonFileService<AITool> _toolDbService;
        private readonly IJsonFileService<Review> _reviewDbService;

        public AdminService(ToolService toolService,IJsonFileService<AITool> toolJsonFileService, IJsonFileService<Review> reviewJsonFileService)
        {
            _toolService = toolService;
            _toolDbService = toolJsonFileService;
            _reviewDbService = reviewJsonFileService;
        }

        public async Task<Review?> ApproveReviewAsync(int id)
        {
            List<Review> reviews = _reviewDbService.Read();
            Review? review = reviews.Find(review => review.Id == id);
            if (review == null) return null;
            review.Status = "Approved";
            _reviewDbService.Write(reviews);
            _toolService.RecalculateRating(review.ToolId);
            return review;
        }

        public async Task<AITool> CreateAIToolAsync(CreateToolDto tool)
        {
            List<AITool> tools = _toolDbService.Read();
            AITool newTool = new AITool
            {
                Id = tools.Max(tool => tool.Id) + 1,
                ToolName = tool.ToolName,
                UseCase = tool.UseCase,
                Category = tool.Category,
                PricingType = tool.PricingType,
                AverageRating = 0.0
            };

            tools.Add(newTool);
            _toolDbService.Write(tools);
            return newTool;
        }

        public async Task<AITool?> DeleteAIToolAsync(int id)
        {
            List<AITool> tools = _toolDbService.Read();
            AITool? toolToRemove = tools.FirstOrDefault(tool => tool.Id == id);

            if (toolToRemove != null)
                tools.Remove(toolToRemove);

            _toolDbService.Write(tools);
            
            return toolToRemove;
        }

        public async Task<Review?> RejectReviewAsync(int id)
        {
            List<Review> reviews = _reviewDbService.Read();
            Review? review = reviews.Find(review => review.Id == id);
            if (review == null) return null;
            review.Status = "Rejected";
            _reviewDbService.Write(reviews);
            _toolService.RecalculateRating(review.ToolId);
            return review;
        }
    }
}