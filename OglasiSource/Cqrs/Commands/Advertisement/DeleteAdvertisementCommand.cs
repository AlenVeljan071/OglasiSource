using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Interfaces;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Advertisement
{
    public class DeleteAdvertisementCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public class DeleteBankCommandValidator : AbstractValidator<DeleteAdvertisementCommand>
        {
            private readonly DbWriteContext _writeContext;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly ITokenService _tokenService;
            public DeleteBankCommandValidator(DbWriteContext writeContext, IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
            {
                _writeContext = writeContext;
                _httpContextAccessor = httpContextAccessor;
                _tokenService = tokenService;

                int userId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]);

                this.ClassLevelCascadeMode = CascadeMode.Stop;
                RuleFor(x => x.Id).NotEmpty()
                      .MustAsync(async (id, cancellation) =>
                      {
                          return await _writeContext.Advertisement.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                      }).WithMessage("Advertisement with this id doesn't exists.");
            }
        }
    }
}
