using FluentValidation;
using MediatR;

namespace OglasiSource.Api.Cqrs.Commands.Account
{
    public class SetNewPasswordCommand : IRequest<Unit>
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }

        public class SetNewPasswordCommandValidator : AbstractValidator<SetNewPasswordCommand>
        {
            public SetNewPasswordCommandValidator()
            {
                ClassLevelCascadeMode = CascadeMode.Stop;
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
    }
}
