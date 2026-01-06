using System.ComponentModel.DataAnnotations;
using AIToolFinder.Services;

namespace AIToolFinder.Dtos.Admin;

public class UpdateApprovalStatusRequest
{
    public ApprovalStatus? Status { get; set; } = null;
}