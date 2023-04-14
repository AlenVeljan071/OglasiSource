using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Account;

namespace MyPersonalTrainer.Api.Handlers.Account
{
    public class SignupAplicationUserHandler : IRequestHandler<SignAccountCommand, SignupVerifyResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDataProtection _dataProtection;
      

        public SignupAplicationUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dataProtection = dataProtection;
          
        }

        public async Task<SignupVerifyResponse> Handle(SignAccountCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<SignAccountCommand, ApplicationUser>(request);
            user.UserType = UserType.User;
            user.Salt = _dataProtection.GenerateSalt();
            user.Password = _dataProtection.Hash(request.Password, user.Salt);
            user.Code = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            user.CodeExpiration = DateTime.UtcNow.AddHours(24);
            _unitOfWork.Repository<OglasiSource.Core.Entities.ApplicationUser>()?.Add(user);
            await _unitOfWork.Complete();


            return new SignupVerifyResponse()
            {
                AplicationUserId = user.Id,
                Email = user.Email!,
            };
        }
    }
}
