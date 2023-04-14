using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Queries.RatingReview;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Core.Responses.RatingReview;
using OglasiSource.Core.Specifications.Review;

namespace OglasiSource.Api.Handlers.RatingReview
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, ReviewResponse>
    {
        private readonly IReadGenericRepository<Core.Entities.Review> _readGenericRepository;
        private readonly IMapper _mapper;

        public GetReviewByIdHandler(IReadGenericRepository<Core.Entities.Review> readGenericRepository, IMapper mapper)
        {
            _readGenericRepository = readGenericRepository;
            _mapper = mapper;
        }
        public async Task<ReviewResponse> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _readGenericRepository.GetEntityWithSpec(new ReviewSpecification(request.Id));
            return _mapper.Map<Core.Entities.Review, ReviewResponse>(review!);
        }
    }
}
