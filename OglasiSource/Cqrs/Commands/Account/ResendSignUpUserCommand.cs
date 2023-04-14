using FluentValidation;
using MediatR;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Cqrs.Commands.Account
{
    public class ResendSignUpUserCommand : IRequest<SignupVerifyResponse>
    {
        public string Email { get; set; }

    }

    public class ResendSignUpUserCommandValidator : AbstractValidator<ResendSignUpUserCommand>
    {
        public ResendSignUpUserCommandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
