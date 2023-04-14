using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Responses.Advertisements;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Queries.Advertisement
{
    public class GetVehicleModelByBrandIdQuery : IRequest<List<VehicleModelResponse>>
    {
        public int Id { get; set; }

        public class GetVehicleModelByBrandIdQueryValidator : AbstractValidator<GetVehicleModelByBrandIdQuery>
        {
            private readonly DbReadContext _readContext;

            public GetVehicleModelByBrandIdQueryValidator(DbReadContext readContext)
            {
                _readContext = readContext;

                this.ClassLevelCascadeMode = CascadeMode.Stop;

                RuleFor(x => x.Id).NotEmpty()
                       .MustAsync(async (id, cancellation) =>
                       {
                           return await _readContext.VehicleBrand.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                       }).WithMessage("Brand id not valid.");
            }
        }
    }
}
