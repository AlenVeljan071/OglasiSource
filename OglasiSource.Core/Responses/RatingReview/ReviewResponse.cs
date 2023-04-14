using OglasiSource.Core.Entities;
using OglasiSource.Core.Responses.User;

namespace OglasiSource.Core.Responses.RatingReview
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public UserResponse User { get; set; }
        public EntityTypeReview EntityTypeReview { get; set; }
        public int? RatingFromTheReviewer { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
