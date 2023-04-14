namespace OglasiSource.Core.Specifications.Review
{
    public class ReviewSpecification : BaseSpecification<Entities.Review>
    {

        public ReviewSpecification(ReviewSpecParams reviewSpecParams) : base(x =>
       (!reviewSpecParams.UserId.HasValue || x.ApplicationUserId == reviewSpecParams.UserId) &&
        (x.EntityTypeReviewId == reviewSpecParams.EntityTypeReviewId))
        {
            AddInclude(x => x.ApplicationUser);
            AddInclude(x => x.EntityTypeReview);
            AddOrderBy(x => x.UpdatedAt,false);
        }
        public ReviewSpecification(int Id, int userId) : base(x =>
        (x.Id == Id) && (x.ApplicationUserId == userId))
        {
            AddInclude(x => x.ApplicationUser);
            AddInclude(x => x.EntityTypeReview);
        }
        public ReviewSpecification(int Id) : base(x =>
       (x.Id == Id))
        {
            AddInclude(x => x.ApplicationUser);
            AddInclude(x => x.EntityTypeReview);
        }
    }
}
