using FluentValidation;
using MediatR;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Cqrs.Commands.Account
{
    public class VerifyForgotPasswordCommand : IRequest<VerifyForgotPasswordResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }

    public class VerifyForgotPasswordCommandValidator : AbstractValidator<VerifyForgotPasswordCommand>
    {
        public VerifyForgotPasswordCommandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}