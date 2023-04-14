using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Api.Helpers;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Interfaces;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Advertisement
{
    public class UpdateAdvertisementPriceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
       
        public decimal? Price { get; set; }
       
      
        public class UpdateAdvertisementPriceCommandValidator : AbstractValidator<UpdateAdvertisementPriceCommand>
        {
            private readonly DbWriteContext _writeContext;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly ITokenService _tokenService;

            public UpdateAdvertisementPriceCommandValidator(DbWriteContext writeContext, IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
            {
                _writeContext = writeContext;
                _httpContextAccessor = httpContextAccessor;
                _tokenService = tokenService;

                ClassLevelCascadeMode = CascadeMode.Stop;

                int aplicationUserId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]!);

                RuleFor(x => x.Id).NotEmpty()
                    .MustAsync(async (id, cancellation) =>
                    {
                        return await _writeContext.Advertisement.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                    }).WithMessage("Advertisement with this id doesn't exists.");

               

            }
        }
    }
}
