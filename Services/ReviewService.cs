namespace AITOOLFINDER.Services
{
    public class ReviewService : IReviewService
    {
        private readonly List<AITool> _tools;

        public ReviewService(List<AITool> tools)
        {
            _tools = tools;
        }

        // POST: submit review
        public Review SubmitReview(ReviewDto reviewDto)
        {
            var tool = _tools.FirstOrDefault(t => t.Id == reviewDto.ToolId);

            if (tool == null)
                return null;

            var review = new Review
            {
                Id = tool.Reviews.Any()
                    ? tool.Reviews.Max(r => r.Id) + 1
                    : 1,
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                Status = ReviewStatus.Pending
            };

            tool.Reviews.Add(review);
            return review;
        }

        // GET: reviews for tool
        public IEnumerable<Review> GetReviewsForTool(Guid toolId)
        {
            var tool = _tools.FirstOrDefault(t => t.Id == toolId);
            return tool?.Reviews;
        }

        // POST: approve/reject review
        public Review SetApprovalStatus(int reviewId, ReviewStatus status)
        {
            var tool = _tools.FirstOrDefault(t =>
                t.Reviews.Any(r => r.Id == reviewId));

            if (tool == null)
                return null;

            var review = tool.Reviews.First(r => r.Id == reviewId);
            review.Status = status;

            RecalculateAverageRating(tool);
            return review;
        }

        private void RecalculateAverageRating(AITool tool)
        {
            var approvedReviews = tool.Reviews
                .Where(r => r.Status == ReviewStatus.Approved)
                .ToList();

            tool.AverageRating = approvedReviews.Any()
                ? approvedReviews.Average(r => r.Rating)
                : 0;
        }
    }
}
