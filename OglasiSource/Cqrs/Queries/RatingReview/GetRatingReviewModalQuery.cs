using MediatR;
using OglasiSource.Core.Responses.RatingReview;

namespace OglasiSource.Api.Cqrs.Queries.RatingReview
{
    public class GetRatingReviewModalQuery : IRequest<GetRatingReviewModalResponse>
    {
    }
}
