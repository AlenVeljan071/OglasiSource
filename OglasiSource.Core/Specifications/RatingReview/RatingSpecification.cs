namespace OglasiSource.Core.Specifications.RatingReview
{
    public class RatingSpecification : BaseSpecification<Entities.Rating>
    {
        public RatingSpecification(int userid, int entityTypeId, int entityTypeRatingId) : base(x =>
        (x.ApplicationUserId == userid) &&
        (x.EntityTypeId == entityTypeId) &&
        (x.EntityTypeRatingId == entityTypeRatingId))
        {
            AddInclude(x => x.ApplicationUser);
            AddInclude(x => x.EntityTypeRating);
        }
    }
}
