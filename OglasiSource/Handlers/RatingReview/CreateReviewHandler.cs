using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Commands.RatingReview;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses;

namespace OglasiSource.Api.Handlers.RatingReview
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, CreateResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateReviewHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateResponse> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            int userId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]);
            var review = _mapper.Map<CreateReviewCommand, Core.Entities.Review>(request);
            review.ApplicationUserId = userId;
            _unitOfWork.Repository<Core.Entities.Review>()?.Add(review);
            await _unitOfWork.Complete();

            return new CreateResponse { Id = review.Id };
        }
    }
}
