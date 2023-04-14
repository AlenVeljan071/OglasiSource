using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Commands.RatingReview;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.RatingReview;
using OglasiSource.Core.Specifications.RatingReview;

namespace OglasiSource.Api.Handlers.RatingReview
{
    public class RatingSetHandler : IRequestHandler<CreateRatingCommand, RatingSetResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RatingSetHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RatingSetResponse> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            int userId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]!);
            var rating = await _unitOfWork.Repository<Rating>()!.GetEntityWithSpec(new RatingSpecification(userId, request.EntityTypeId, request.EntityTypeRatingId));
            var entityRatingType = await _unitOfWork.Repository<EntityTypeRating>()!.GetByIdAsync(request!.EntityTypeRatingId);
            var ratingResponse = new RatingSetResponse();
            ratingResponse.EntityId = request.EntityTypeId;
            ratingResponse.EntityType = new EnumValue { Id = entityRatingType!.Id, Name = entityRatingType!.Name };
            if (rating == null)
            {
                rating = _mapper.Map<CreateRatingCommand, Rating>(request);
                rating.ApplicationUserId = userId;
                if (entityRatingType!.Name == Constants.User)
                {
                    var ratinguser = await _unitOfWork.Repository<ApplicationUser>()!.GetByIdAsync(rating.EntityTypeId);
                    if (request.Thumb == 1)
                    {
                        ratinguser!.UpCount += 1;
                    }
                    else
                    {
                        ratinguser!.DownCount += 1;
                    }
                    ratinguser.Rating = ratinguser.UpCount - ratinguser.DownCount;
                    ratingResponse.UpCount = ratinguser!.UpCount;
                    ratingResponse.DownCount = ratinguser!.DownCount;
                    ratingResponse.CurrentAplicationUserRating = request.Thumb;
                    _unitOfWork.Repository<ApplicationUser>()!.Update(ratinguser);
                }
                _unitOfWork.Repository<Rating>()?.Add(rating);
            }
            else if (rating.Thumb != request.Thumb)
            {

                rating.Thumb = request.Thumb;
                if (entityRatingType!.Name == Constants.User)
                {
                    var ratinguser = await _unitOfWork.Repository<ApplicationUser>()!.GetByIdAsync(rating.EntityTypeId);
                    if (request.Thumb == 1)
                    {
                        ratinguser!.UpCount += 1;
                        ratinguser!.DownCount -= 1;
                    }
                    else
                    {
                        ratinguser!.DownCount += 1;
                        ratinguser!.UpCount -= 1;
                    }
                    ratinguser.Rating = ratinguser.UpCount - ratinguser.DownCount;
                    ratingResponse.UpCount = ratinguser!.UpCount;
                    ratingResponse.DownCount = ratinguser!.DownCount;
                    ratingResponse.CurrentAplicationUserRating = request.Thumb;
                    _unitOfWork.Repository<ApplicationUser>()!.Update(ratinguser);
                }
                _unitOfWork.Repository<Rating>()?.Update(rating);
            }

            else
            {
                if (entityRatingType!.Name == Constants.User)
                {
                    var ratinguser = await _unitOfWork.Repository<ApplicationUser>()!.GetByIdAsync(rating.EntityTypeId);
                    if (request.Thumb == 1)
                    {
                        ratinguser!.UpCount -= 1;
                    }
                    else
                    {
                        ratinguser!.DownCount -= 1;
                    }

                    ratinguser.Rating = ratinguser.UpCount - ratinguser.DownCount;
                    ratingResponse.UpCount = ratinguser!.UpCount;
                    ratingResponse.DownCount = ratinguser!.DownCount;
                    ratingResponse.CurrentAplicationUserRating = null;
                    _unitOfWork.Repository<ApplicationUser>()!.Update(ratinguser);
                }

                _unitOfWork.Repository<Rating>()?.Delete(rating);
            }
                await _unitOfWork.Complete();

                return ratingResponse;
            
        }
    }
}
