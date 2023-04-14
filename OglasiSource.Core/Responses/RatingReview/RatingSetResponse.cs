
using OglasiSource.Core.Enums;

namespace OglasiSource.Core.Responses.RatingReview
{
    public class RatingSetResponse
    {
        public EnumValue EntityType { get; set; }
        public int EntityId { get; set; }
        public int UpCount { get; set; }
        public int DownCount { get; set; }
        public int? CurrentAplicationUserRating { get; set; }
    }
}
