using MediatR;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Errors;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Handlers.Account
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, SignInResponse>
    {
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public RefreshTokenHandler(ITokenService tokenService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<SignInResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            string refreshToken = request.RefreshToken!;
            string token = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]!;
            var userId = _tokenService.ReadUserId(token);
            var user = await _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.GetFirstAsync(x => x.Id == userId, x => x);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                throw new NotFoundException("404", "Refresh token is not valid.");
            var newAccessToken = _tokenService.SecurityToken(_tokenService.ReadToken(token));
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.MaxValue;
            _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.Update(user!);
            await _unitOfWork.Complete();

            return new SignInResponse()
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
    }
}
