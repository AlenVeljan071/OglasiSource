using MediatR;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Errors;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Handlers.Account
{
    public class SignInHandler : IRequestHandler<SignInCommand, SignInResponse>
    {
        private readonly IDataProtection _dataProtection;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public SignInHandler(IDataProtection dataProtection, ITokenService tokenService, IUnitOfWork unitOfWork)
        {
            _dataProtection = dataProtection;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.GetFirstAsync(x => x.Email == request.Email, x => x);
            if (user == null) throw new UnauthorizedException("401", "This user doesn't exist.");

            if (!user.Verified) throw new UnauthorizedException("401", "Please verify your email.");

            var hashedPassword = _dataProtection.Hash(request.Password, user.Salt!);
            if (user.Password != hashedPassword) throw new UnauthorizedException("401", "Wrong password, try again.");


            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(8);


            _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.Update(user!);
            await _unitOfWork.Complete();
            
            var token = user.UserType == Core.Enums.UserType.User ? _tokenService.CreateToken(user.Id, user.Email!) : _tokenService.CreateToken(user.Id, user.Email!);
            return new SignInResponse
            {
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Token =   token,
                Avatar = user.Avatar != null ? Convert.ToBase64String(user.Avatar!) : null,
                AplicationUserId = user.Id,
                RefreshToken = refreshToken
            };



        }
    }
}
