namespace AIToolFinder.Services.Admin;

public interface IAdminService
{
    Task<AITool> CreateAIToolAsync(CreateToolDto tool);
    Task<AITool?> DeleteAIToolAsync(int id);
    Task<Review?> ApproveReviewAsync(int id);
    Task<Review?> RejectReviewAsync(int id);

}
