using OglasiSource.Core.Entities;


namespace OglasiSource.Core.Responses.RatingReview
{
    public class RatingResponse
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public EntityTypeRating EntityTypeRating { get; set; }
        public int Thumb { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
