using MediatR;
using Microsoft.Extensions.Options;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Errors;
using OglasiSource.Api.Helpers;
using OglasiSource.Core.Config;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Handlers.Account
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand, SignupVerifyResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ForgotPasswordHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SignupVerifyResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.GetFirstAsync(x => x.Email == request.Email, x => x);
            if (!user!.Verified) throw new BadRequestException("400", "Please verify your email.");
            user.Code = Calculations.Generate4digit().ToString();
            user.CodeExpiration = DateTime.UtcNow.AddHours(24);
            _unitOfWork.Repository<Core.Entities.ApplicationUser>()?.Update(user);
            await _unitOfWork.Complete();

            return new SignupVerifyResponse()
            {
                Email = user.Email!,
            };
        }
    }
}
