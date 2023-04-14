using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Api.Helpers;
using OglasiSource.Core.Responses.Account;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Account
{
    public class ForgotPasswordCommand : IRequest<SignupVerifyResponse>
    {

        public string Email { get; set; }
    }

    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        private readonly DbWriteContext _writeContext;


        public ForgotPasswordCommandValidator(DbWriteContext writeContext)
        {
            _writeContext = writeContext;
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email).SetValidator(new EmailAddressValidator())
                .MustAsync(async (email, cancellation) =>
                {
                    return await _writeContext.ApplicationUser.AsNoTracking().AnyAsync(x => x.Email == email, cancellationToken: cancellation);
                }).WithMessage("Email doesn't exists.");

        }
    }
}
