using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Queries.Comment;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Helpers;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Core.Responses.Comment;
using OglasiSource.Core.Responses.RatingReview;
using OglasiSource.Core.Specifications.Comment;

namespace OglasiSource.Api.Handlers.Comment
{
    public class GetCommentByEntityTypeListHandler : IRequestHandler<GetCommentByEntityTypeListQuery, CommentByEntityTypeListResponse>
    {
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IReadGenericRepository<Core.Entities.Comment> _readGenericRepository;
        private readonly IReadGenericRepository<Core.Entities.Rating> _readRatingRepository;

        private readonly IMapper _mapper;


        public GetCommentByEntityTypeListHandler(ITokenService tokenService, IReadGenericRepository<Core.Entities.Comment> readGenericRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IReadGenericRepository<Core.Entities.Rating> readRatingRepository)
        {
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
            _readGenericRepository = readGenericRepository;
            _mapper = mapper;
            _readRatingRepository = readRatingRepository;
        }

        public async Task<CommentByEntityTypeListResponse> Handle(GetCommentByEntityTypeListQuery request, CancellationToken cancellationToken)
        {
            request.CommentSpecParams.UserId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]);
            var totalItems = await _readGenericRepository.CountAsync(new CommentCountSpecification(request.CommentSpecParams));
            var comments = await _readGenericRepository.ListAsync(new CommentSpecification(request.CommentSpecParams));
            var commentsResponse = _mapper.Map<IReadOnlyList<CommentResponse>>(comments);
            var entityTypeConst = DictionaryExtensions.GetValues(Constants.EntityTypeRating).Where(x => x.Name == Constants.Comment).FirstOrDefault();
            foreach (var comment in commentsResponse)
            {
                var ratings = await _readRatingRepository.GetAsync(x => x.EntityTypeId == comment!.Id && x.EntityTypeRatingId == entityTypeConst!.Id,
                                       x => new RatingResponse { Thumb = x.Thumb, ApplicationUser = new Core.Entities.ApplicationUser { Id = x.ApplicationUserId } });
                comment.UpRatingCount = ratings.Where(x => x.Thumb == 1).Count();
                comment.DownRatingCount = ratings.Where(x => x.Thumb == -1).Count();
                comment.CurrentCompanyUserRating = ratings.Any(x => x.ApplicationUser.Id == _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0])) ?
                    ratings.First(x => x.ApplicationUser.Id == _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0])).Thumb : null;
            }
            return new CommentByEntityTypeListResponse
            {
                Pagination = new Pagination<CommentResponse>(request.CommentSpecParams.PageIndex, request.CommentSpecParams.PageSize, totalItems, commentsResponse)
            };

        }
    }
}
