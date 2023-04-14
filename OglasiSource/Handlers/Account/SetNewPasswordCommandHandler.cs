using MediatR;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Errors;
using OglasiSource.Core.Interfaces;

namespace OglasiSource.Api.Handlers.Account
{
    public class SetNewPasswordCommandHandler : IRequestHandler<SetNewPasswordCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataProtection _dataProtection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;

        public SetNewPasswordCommandHandler(IUnitOfWork unitOfWork, IDataProtection dataProtection, IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _dataProtection = dataProtection;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
        }

        public async Task<Unit> Handle(SetNewPasswordCommand request, CancellationToken cancellationToken)
        {

            var user = await _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.GetFirstAsync(x => x.Email == request.Email && x.Code == request.Code, x => x);
            if (user == null) throw new BadRequestException("400", "Invalid verification code.");
            user!.Password = _dataProtection.Hash(request.Password, user.Salt!);
            user.Code = null;
            user.CodeExpiration = null;
            _unitOfWork.Repository<Core.Entities.ApplicationUser>()?.Update(user);
            await _unitOfWork.Complete();
            return new Unit();

        }
    }
}
