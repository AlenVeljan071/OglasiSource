using OglasiSource.Core.Enums;
    
namespace OglasiSource.Core.Responses.RatingReview
{
    public class GetRatingReviewModalResponse
    {
        public List<EnumValue> EntityTypeRating { get; set; }
        public List<EnumValue> EntityTypeReview { get; set; }
    }
}
