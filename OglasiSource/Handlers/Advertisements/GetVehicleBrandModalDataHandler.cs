using MediatR;
using OglasiSource.Api.Cqrs.Queries.Advertisement;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Core.Responses.Advertisements;

namespace OglasiSource.Api.Handlers.Advertisements
{
    public class GetVehicleBrandModalDataHandler : IRequestHandler<GetVehicleBrandByCatergoryIdQuery, List<VehicleBrandResponse>>
    {
        private readonly IReadGenericRepository<Core.Entities.VehicleBrand> _readGenericRepository;


        public GetVehicleBrandModalDataHandler(IReadGenericRepository<Core.Entities.VehicleBrand> readGenericRepository)
        {
            _readGenericRepository = readGenericRepository;
        }

        public async Task<List<VehicleBrandResponse>> Handle(GetVehicleBrandByCatergoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _readGenericRepository.GetAsync(x => x.SubcategoryId == request.Id, x => new VehicleBrandResponse { Id = x.Id, Name = x.Name, SubcategoryId = x.SubcategoryId! });
        }
    }
}
