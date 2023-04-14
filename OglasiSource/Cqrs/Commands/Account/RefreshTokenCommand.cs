using MediatR;
using OglasiSource.Core.Responses.Account;

namespace OglasiSource.Api.Cqrs.Commands.Account
{
    public class RefreshTokenCommand : IRequest<SignInResponse>
    {
        public string? RefreshToken { get; set; }
    }
}
