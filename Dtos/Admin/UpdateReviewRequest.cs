using System.ComponentModel.DataAnnotations;
using AIToolFinder.Services;

namespace AIToolFinder.Dtos.Admin;

public class UpdateReviewRequest
{
    public ApprovalStatus? Status { get; set; } = null;
}