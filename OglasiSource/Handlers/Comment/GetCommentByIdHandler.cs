using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Queries.Comment;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Core.Responses.Comment;
using OglasiSource.Core.Responses.RatingReview;
using OglasiSource.Core.Specifications.Comment;

namespace MyPersonalTrainer.Api.Handlers.Comment
{
    public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, CommentResponse>
    {
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IReadGenericRepository<OglasiSource.Core.Entities.Comment> _readGenericRepository;
        private readonly IReadGenericRepository<OglasiSource.Core.Entities.Rating> _readRatingRepository;
        private readonly IMapper _mapper;

        public GetCommentByIdHandler(ITokenService tokenService, IReadGenericRepository<OglasiSource.Core.Entities.Comment> readGenericRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IReadGenericRepository<OglasiSource.Core.Entities.Rating> readRatingRepository)
        {
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
            _readGenericRepository = readGenericRepository;
            _readRatingRepository = readRatingRepository;
            _mapper = mapper;
        }

        public async Task<CommentResponse> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var companyId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]);
            var comment = await _readGenericRepository.GetEntityWithSpec(new CommentSpecification(request.Id, companyId));
            var commentResponse = _mapper.Map<OglasiSource.Core.Entities.Comment, CommentResponse>(comment!);

            var entityTypeConst = DictionaryExtensions.GetValues(Constants.EntityTypeRating).Where(x => x.Name == Constants.Comment).FirstOrDefault();

            var ratings = await _readRatingRepository.GetAsync(x => x.EntityTypeId == comment!.Id && x.EntityTypeRatingId == entityTypeConst!.Id,
                                          x => new RatingResponse { Thumb = x.Thumb, ApplicationUser = new OglasiSource.Core.Entities.ApplicationUser { Id = x.ApplicationUserId } });

            commentResponse.UpRatingCount = ratings.Where(x => x.Thumb == 1).Count();
            commentResponse.DownRatingCount = ratings.Where(x => x.Thumb == -1).Count();
            commentResponse.CurrentCompanyUserRating = ratings.Any(x => x.ApplicationUser.Id == _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0])) ?
                ratings.First(x => x.ApplicationUser.Id == _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0])).Thumb : null;
            return commentResponse;
        }
    }
}
