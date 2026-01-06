using System.ComponentModel.DataAnnotations;

namespace AIToolFinder.Dtos.Reviews;

public class UpdateReviewRequest
{
    public int? Rating { get; set; }
    public string? Comment { get; set; }
}
