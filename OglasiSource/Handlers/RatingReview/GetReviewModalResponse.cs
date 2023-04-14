using MediatR;
using OglasiSource.Api.Cqrs.Queries.RatingReview;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Responses.RatingReview;

namespace OglasiSource.Api.Handlers.RatingReview
{
    public class GetModalResponseRatingReview : IRequestHandler<GetRatingReviewModalQuery, GetRatingReviewModalResponse>
    {

        public GetModalResponseRatingReview()
        {

        }
        public async Task<GetRatingReviewModalResponse> Handle(GetRatingReviewModalQuery request, CancellationToken cancellationToken)
        {

            var response = new GetRatingReviewModalResponse
            {
                EntityTypeRating = DictionaryExtensions.GetValues(Constants.EntityTypeRating),
                EntityTypeReview = DictionaryExtensions.GetValues(Constants.EntityTypeReview)
            };
            return await Task.FromResult(response);
        }
    }
}
