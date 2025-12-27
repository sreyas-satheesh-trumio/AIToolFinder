using System.ComponentModel.DataAnnotations;

public class UpdateReviewDto
{
    [Required(ErrorMessage = "Status is required")]
    public ReviewStatus? Status { get; set; }
}