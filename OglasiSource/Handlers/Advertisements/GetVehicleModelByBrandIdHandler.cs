using MediatR;
using OglasiSource.Api.Cqrs.Queries.Advertisement;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Core.Responses.Advertisements;

namespace OglasiSource.Api.Handlers.Advertisements
{
    public class GetVehicleModelByBrandIdHandler : IRequestHandler<GetVehicleModelByBrandIdQuery, List<VehicleModelResponse>>
    {
        private readonly IReadGenericRepository<Core.Entities.VehicleModel> _readGenericRepository;
       

        public GetVehicleModelByBrandIdHandler(IReadGenericRepository<Core.Entities.VehicleModel> readGenericRepository)
        {
            _readGenericRepository = readGenericRepository;
        }

        public async Task<List<VehicleModelResponse>> Handle(GetVehicleModelByBrandIdQuery request, CancellationToken cancellationToken)
        {
            return await _readGenericRepository.GetAsync(x => x.VehicleBrandId == request.Id, x => new VehicleModelResponse { Id = x.Id, Name = x.Name, VehicleBrandId = x.VehicleBrandId! });
        }
    }
 
}
