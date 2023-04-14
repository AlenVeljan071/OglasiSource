using FluentValidation;
using MediatR;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Cqrs.Commands.Account
{
    public class VerifyUserCommand : IRequest<SignupVerifyResponse>
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }

    public class VerifyUserCommandValidator : AbstractValidator<VerifyUserCommand>
    {
        public VerifyUserCommandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
