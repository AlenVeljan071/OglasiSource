using MediatR;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Errors;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Account;

namespace MyPersonalTrainer.Api.Handlers.Account
{
    public class VerifyForgotPasswordHandler : IRequestHandler<VerifyForgotPasswordCommand, VerifyForgotPasswordResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataProtection _dataProtection;
        private readonly ITokenService _tokenService;

        public VerifyForgotPasswordHandler(IDataProtection dataProtection, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _dataProtection = dataProtection;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }


        public async Task<VerifyForgotPasswordResponse> Handle(VerifyForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<OglasiSource.Core.Entities.ApplicationUser>()!.GetFirstAsync(x => x.Code == request.Code, x => x);
            if (user == null) throw new BadRequestException("400", "Invalid verification code.");
            if (user.CodeExpiration <= DateTime.UtcNow) throw new BadRequestException("400", "Verification code expired.");
            user.Password = request.Password;
            _unitOfWork.Repository<OglasiSource.Core.Entities.ApplicationUser>()!.Update(user!);
            await _unitOfWork.Complete();
            return new VerifyForgotPasswordResponse
            {
                Token =  _tokenService.CreateToken(user.Id, user.Email!),
            };


        }

    }
}