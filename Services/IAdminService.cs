namespace AIToolFinder.Services
{
    public interface IAdminService
    {
        Task<AITool> CreateAIToolAsync(AITool tool);
        Task<AITool?> DeleteAIToolAsync(int id);
        Task<Review?> ApproveReviewAsync(int id);
        Task<Review?> RejectReviewAsync(int id);
    }
}