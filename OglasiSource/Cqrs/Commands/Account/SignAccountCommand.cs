using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Api.Helpers;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Account;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Account
{
    public class SignAccountCommand : IRequest<SignupVerifyResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressEntity Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Avatar { get; set; }

        public class SignAccountCommandValidator : AbstractValidator<SignAccountCommand>
        {
            private readonly DbWriteContext _writeContext;
            private readonly IDataProtection _dataProtection;
            public SignAccountCommandValidator(DbWriteContext writeContext, IDataProtection dataProtection)
            {
                _writeContext = writeContext;
                _dataProtection = dataProtection;

                ClassLevelCascadeMode = CascadeMode.Stop;

                RuleFor(x => x.FirstName).SetValidator(new FirstNameValidator());
                RuleFor(x => x.LastName).SetValidator(new LastNameValidator());
                RuleFor(x => x.Address).SetValidator(new AddressEntityValidator());

                RuleFor(x => x.Phone).SetValidator(new PhoneValidator())
                      .MustAsync(async (phone, cancellation) =>
                      {
                          return !await _writeContext.ApplicationUser.AsNoTracking().AnyAsync(x => x.Phone == phone, cancellationToken: cancellation);
                      }).WithMessage("Phone already exists.");

                RuleFor(x => x.Email).SetValidator(new EmailAddressValidator())
                    .MustAsync(async (email, cancellation) =>
                    {
                        return !await _writeContext.ApplicationUser.AsNoTracking().AnyAsync(x => x.Email == email, cancellationToken: cancellation);
                    }).WithMessage("Email already exists.");

                RuleFor(x => x.Password).NotEmpty()
                    .Length(0, 100).WithMessage("Password should have 100 chars at most.");
            }
        }
    }
}
