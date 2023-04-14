using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Responses.Advertisements;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Queries.Advertisement
{
    public class GetAdvertisementByIdQuery : IRequest<AdvertisementResponse>
    {
        public int Id { get; set; }

        public class GetAdvertisementByIdQueryValidator : AbstractValidator<GetAdvertisementByIdQuery>
        {
            private readonly DbReadContext _readContext;

            public GetAdvertisementByIdQueryValidator(DbReadContext readContext)
            {
                _readContext = readContext;

                this.ClassLevelCascadeMode = CascadeMode.Stop;

                RuleFor(x => x.Id).NotEmpty()
                       .MustAsync(async (id, cancellation) =>
                       {
                           return await _readContext.Advertisement.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                       }).WithMessage("Advertisement id not valid.");
            }
        }
    }
}
