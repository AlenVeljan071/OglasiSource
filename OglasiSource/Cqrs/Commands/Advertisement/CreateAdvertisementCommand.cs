using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Api.Helpers;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Advertisement
{
    public class CreateAdvertisementCommand : IRequest<CreateResponse>
    {
        public int SubCategoryId { get; set; }
        public decimal? Price { get; set; }
        public int? VehicleBrandId { get; set; }
        public int? VehicleModelId { get; set; }
        public AddressEntity? Address { get; set; }
        public int? Color { get; set; }
        public int? Year { get; set; }
        public Fuel? Fuel { get; set; }
        public Drive? Drive { get; set; }
        public ParkingSensors? ParkingSensors { get; set; }
        public decimal? Mileage { get; set; }
        public int? KW { get; set; }
        public int? CCM { get; set; }
        public int? HorsePower { get; set; }
        public int? Weight { get; set; }
        public int? Shifter { get; set; }
        public int? Gear { get; set; }
        public int? Emission { get; set; }
        public int? Seat { get; set; }
        public bool? Abs { get; set; }
        public bool? Airbag { get; set; }
        public bool? Alarm { get; set; }
        public bool? AluminiumRims { get; set; }
        public bool? CentralLock { get; set; }
        public bool? DpfFilter { get; set; }
        public bool? DigitalClimate { get; set; }
        public bool? RemoteUnlocking { get; set; }
        public bool? ElectricWindows { get; set; }
        public bool? ElectricMirrors { get; set; }
        public bool? SeatHeating { get; set; }
        public bool? SteeringWheelControls { get; set; }
        public bool? Navigation { get; set; }
        public bool? ParkAssist { get; set; }
        public bool? ServiceBook { get; set; }
        public bool? CruiseControl { get; set; }
        public bool? Damaged { get; set; }
        public bool? Registered { get; set; }
        public string? Note { get; set; }

        public class CreateAdvertisementCommandValidator : AbstractValidator<CreateAdvertisementCommand>
        {
            private readonly DbWriteContext _writeContext;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly ITokenService _tokenService;

            public CreateAdvertisementCommandValidator(DbWriteContext writeContext, IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
            {
                _writeContext = writeContext;
                _httpContextAccessor = httpContextAccessor;
                _tokenService = tokenService;

                ClassLevelCascadeMode = CascadeMode.Stop;

                int aplicationUserId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]!);

                RuleFor(x => x.SubCategoryId).NotEmpty()
               .MustAsync(async (id, cancellation) =>
               {
                   return await _writeContext.SubCategory.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
               }).WithMessage("Sub category with this id doesn't exist.");
               
                RuleFor(x => x.Name).SetValidator(new NameValidator());
              
            }
        }
  
    }
}
