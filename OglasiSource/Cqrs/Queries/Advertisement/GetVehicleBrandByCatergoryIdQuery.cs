using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Responses.Advertisements;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Queries.Advertisement
{
    public class GetVehicleBrandByCatergoryIdQuery : IRequest<List<VehicleBrandResponse>>
    {
        public int Id { get; set; }

        public class GetVehicleBrandByCatergoryIdQueryValidator : AbstractValidator<GetVehicleBrandByCatergoryIdQuery>
        {
            private readonly DbReadContext _readContext;

            public GetVehicleBrandByCatergoryIdQueryValidator(DbReadContext readContext)
            {
                _readContext = readContext;

                this.ClassLevelCascadeMode = CascadeMode.Stop;

                RuleFor(x => x.Id).NotEmpty()
                       .MustAsync(async (id, cancellation) =>
                       {
                           return await _readContext.SubCategory.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                       }).WithMessage("Category id not valid.");
            }
        }
    }
}
