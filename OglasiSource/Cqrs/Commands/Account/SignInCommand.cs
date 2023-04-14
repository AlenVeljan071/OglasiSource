using FluentValidation;
using MediatR;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Cqrs.Commands.Account
{
    public class SignInCommand : IRequest<SignInResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
