using MediatR;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Errors;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Handlers.Account
{
    public class VerifyUserHandler : IRequestHandler<VerifyUserCommand, SignupVerifyResponse>
    {
        private readonly IUnitOfWork _unitOfWork;


        public VerifyUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SignupVerifyResponse> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.GetFirstAsync(x => x.Code == request.Code && x.Email == request.Email, x => x);
            if (user == null) throw new BadRequestException("400", "Invalid verification code or user already verified.");
            if (user.Verified) throw new BadRequestException("400", "User already verified.");
            if (user.CodeExpiration <= DateTime.UtcNow) throw new BadRequestException("400", "Verification code expired.");
            user.Verified = true;
            user.Code = null;
            user.CodeExpiration = null;
            await _unitOfWork.Complete();


            return new SignupVerifyResponse()
            {
                Email = user.Email!,
            };
        }
    }
}
