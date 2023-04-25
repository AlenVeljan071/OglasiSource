using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OglasiSource.Core.Specifications.Review;

namespace OglasiSource.Core.Specifications.RatingReview
{
    public class ReviewCountSpecification : BaseSpecification<Entities.Review>
    {
        public ReviewCountSpecification(ReviewSpecParams reviewSpecParams) : base(x =>
            (!reviewSpecParams.ApplicationUserId.HasValue || x.ApplicationUserId == reviewSpecParams.ApplicationUserId) &&
            (x.EntityTypeReviewId == reviewSpecParams.EntityTypeReviewId)
        )
        {

        }
    }
}
