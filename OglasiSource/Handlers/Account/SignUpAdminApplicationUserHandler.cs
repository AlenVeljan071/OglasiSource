using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using MyPersonalTrainer.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Helpers;
using OglasiSource.Core.Config;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Account;
using System.Net.Mail;

namespace OglasiSource.Api.Handlers.Account
{
    public class SignUpAdminApplicationUserHandler : IRequestHandler<SignAdminAccountCommand, SignupVerifyResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDataProtection _dataProtection;
      
        public SignUpAdminApplicationUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dataProtection = dataProtection;
        }

        public async Task<SignupVerifyResponse> Handle(SignAdminAccountCommand request, CancellationToken cancellationToken)
        {
           
            var user = _mapper.Map<SignAdminAccountCommand, ApplicationUser>(request);
            _unitOfWork.Repository<ApplicationUser>()?.Add(user);
            user.UserType = UserType.Admin;
            user.Salt = _dataProtection.GenerateSalt();
            user.Password = _dataProtection.Hash(request.Password, user.Salt);
            user.Code = Calculations.Generate4digit().ToString();
            user.CodeExpiration = DateTime.UtcNow.AddHours(24);
          
            await _unitOfWork.Complete();

         
            return new SignupVerifyResponse()
            {
                AplicationUserId = user.Id,
                Email = user.Email!,
            };
        }
    }
}
