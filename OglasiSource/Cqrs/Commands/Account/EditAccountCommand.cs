using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Api.Helpers;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Interfaces;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Account
{
    public class EditAccountCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressEntity Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string? Avatar { get; set; }

        public class EditAccountCommandValidator : AbstractValidator<EditAccountCommand>
        {
            private readonly DbWriteContext _writeContext;
            private readonly IDataProtection _dataProtection;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly ITokenService _tokenService;
            public EditAccountCommandValidator(DbWriteContext writeContext, IDataProtection dataProtection, IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
            {
                _writeContext = writeContext;
                _dataProtection = dataProtection;
                _httpContextAccessor = httpContextAccessor;
                _tokenService = tokenService;

                ClassLevelCascadeMode = CascadeMode.Stop;

                int aplicationUserId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]!);


                RuleFor(x => x.Id).NotEmpty()
                 .MustAsync(async (id, cancellation) =>
                 {
                    return await _writeContext.ApplicationUser.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                 }).WithMessage("Application user with this id doesn't exist.");

                RuleFor(x => x.FirstName).SetValidator(new FirstNameValidator());
                RuleFor(x => x.LastName).SetValidator(new LastNameValidator());
                RuleFor(x => x.Address).SetValidator(new AddressEntityValidator());

                RuleFor(x => x.Phone).SetValidator(new PhoneValidator())
                      .MustAsync(async (phone, cancellation) =>
                      {
                          return !await _writeContext.ApplicationUser.AsNoTracking().AnyAsync(x => x.Phone == phone && x.Id != aplicationUserId, cancellationToken: cancellation);
                      }).WithMessage("Phone already exists.");


                RuleFor(x => x.Password).NotEmpty()
                    .Length(0, 100).WithMessage("Password should have 100 chars at most.");
              
            }
        }
    }
}
