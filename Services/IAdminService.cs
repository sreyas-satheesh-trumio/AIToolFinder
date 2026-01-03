public interface IAdminService
{
    void AddTool(AITool tool);
    void DeleteTool(int id);
    void ApproveReview(int reviewId);
    void RejectReview(int reviewId);
}
