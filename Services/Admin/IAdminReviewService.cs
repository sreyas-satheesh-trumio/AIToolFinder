using AIToolFinder.Dtos.Admin;

namespace AIToolFinder.Services.Admin;

public interface IAdminReviewService
{
    Task<Review?> UpdateAsync(int id, UpdateApprovalStatusRequest updateData);
}

