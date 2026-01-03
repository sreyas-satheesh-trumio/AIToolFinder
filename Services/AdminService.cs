using AIToolFinder.Dtos;
using AIToolFinder.Enums;
using Microsoft.EntityFrameworkCore;


namespace AIToolFinder.Services
{
    public class AdminService : IAdminService
    {
        private readonly ToolService _toolService;
        private readonly AppDbContext _context;

        public AdminService(ToolService toolService,AppDbContext context)
        {
            _toolService = toolService;
            _context = context;
        }

        public async Task<Review?> ApproveReviewAsync(int id)
        {
            Review? review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);

            if (review == null)
                return null;

            // Optional: prevent re-approval
            if (review.Status == "Approved")
                return review;

            review.Status = "Approved";

            await _context.SaveChangesAsync();

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

            _context.AITools.Add(newTool);
            await _context.SaveChangesAsync();

            return newTool;
        }




        public async Task<AITool?> DeleteAIToolAsync(int id)
        {
            AITool? tool = await _context.AITools.FirstOrDefaultAsync(t => t.Id == id);

            if (tool == null)
                return null;

            _context.AITools.Remove(tool);
            await _context.SaveChangesAsync();

            return tool;
        }


        public async Task<Review?> RejectReviewAsync(int id)
        {
            Review? review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);

            if (review == null)
                return null;

            review.Status = "Rejected";

            await _context.SaveChangesAsync();

            return review;
        }



    }
}