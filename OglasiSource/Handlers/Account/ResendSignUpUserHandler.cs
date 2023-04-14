using MediatR;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Errors;
using OglasiSource.Api.Helpers;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Handlers.Account
{
    public class ResendSignUpUserHandler : IRequestHandler<ResendSignUpUserCommand, SignupVerifyResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
     

        public ResendSignUpUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        public async Task<SignupVerifyResponse> Handle(ResendSignUpUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.GetFirstAsync(x => x.Email == request.Email, x => x);
            if (user == null) throw new NotFoundException("404", "User not found.");
            if (user.Verified == true) throw new BadRequestException("400", "User already verified.");

            user.Code = Calculations.Generate4digit().ToString();
            user.CodeExpiration = DateTime.UtcNow.AddHours(24);

            _unitOfWork.Repository<Core.Entities.ApplicationUser>()?.Update(user);
            await _unitOfWork.Complete();

            return new SignupVerifyResponse();

        }
    }
}
