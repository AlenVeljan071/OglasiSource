using MediatR;
using OglasiSource.Core.Responses.RatingReview;
using OglasiSource.Core.Specifications.Review;

namespace OglasiSource.Api.Cqrs.Queries.RatingReview
{
    public class ReviewbByEntityTypeListQuery : IRequest<ReviewByEntityTypeListResponse>
    {
        public ReviewSpecParams ReviewSpecParams { get; set; }
    }
}
