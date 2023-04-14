using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Queries.RatingReview;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Helpers;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Core.Responses.RatingReview;
using OglasiSource.Core.Specifications.RatingReview;
using OglasiSource.Core.Specifications.Review;

namespace OglasiSource.Api.Handlers.RatingReview
{
    public class GetReviewByEntityTypeListHandler : IRequestHandler<ReviewbByEntityTypeListQuery, ReviewByEntityTypeListResponse>
    {
        private readonly IReadGenericRepository<Review> _readGenericRepository;
        private readonly IMapper _mapper;

        public GetReviewByEntityTypeListHandler(IReadGenericRepository<Review> readGenericRepository, IMapper mapper)
        {
            _readGenericRepository = readGenericRepository;
            _mapper = mapper;
        }

        public async Task<ReviewByEntityTypeListResponse> Handle(ReviewbByEntityTypeListQuery request, CancellationToken cancellationToken)
        {
            var totalItems = await _readGenericRepository.CountAsync(new ReviewCountSpecification(request.ReviewSpecParams));
            var reviews = await _readGenericRepository.ListAsync(new ReviewSpecification(request.ReviewSpecParams));
            var reviewsResponse = _mapper.Map<IReadOnlyList<ReviewResponse>>(reviews);

            return new ReviewByEntityTypeListResponse
            {
                Pagination = new Pagination<ReviewResponse>(request.ReviewSpecParams.PageIndex, request.ReviewSpecParams.PageSize, totalItems, reviewsResponse)
            };

        }
    }
}
