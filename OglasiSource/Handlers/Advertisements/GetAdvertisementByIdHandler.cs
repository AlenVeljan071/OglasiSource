using AutoMapper;
using MediatR;
using Microsoft.OpenApi.Extensions;
using OglasiSource.Api.Cqrs.Queries.Advertisement;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Core.Responses.Advertisements;
using OglasiSource.Core.Specifications.Advertisement;

namespace OglasiSource.Api.Handlers.Advertisements
{
    public class GetAdvertisementByIdHandler : IRequestHandler<GetAdvertisementByIdQuery, AdvertisementResponse>
    {
        private readonly IReadGenericRepository<Core.Entities.Advertisement> _readGenericRepository;
        private readonly IReadGenericRepository<Core.Entities.VehicleBrand> _readGenericBrandRepository;
        private readonly IReadGenericRepository<Core.Entities.VehicleModel> _readGenericModelRepository;
        private readonly IMapper _mapper;

        public GetAdvertisementByIdHandler(IReadGenericRepository<Core.Entities.Advertisement> readGenericRepository, IMapper mapper, IReadGenericRepository<Core.Entities.VehicleBrand> readGenericBrandRepository = null, IReadGenericRepository<Core.Entities.VehicleModel> readGenericModelRepository = null)
        {
            _readGenericRepository = readGenericRepository;
            _mapper = mapper;
            _readGenericBrandRepository = readGenericBrandRepository;
            _readGenericModelRepository = readGenericModelRepository;
        }

        public async Task<AdvertisementResponse> Handle(GetAdvertisementByIdQuery request, CancellationToken cancellationToken)
        {
            var advertisement = await _readGenericRepository.GetEntityWithSpec(new AdvertisementSpecification(request.Id));
            var response = _mapper.Map<Core.Entities.Advertisement, AdvertisementResponse>(advertisement!);
            response.VehicleBrand = await _readGenericBrandRepository.GetFirstAsync(x=>x.Id == advertisement!.VehicleBrandId, x => new VehicleBrand { Id = x.Id, Name = x.Name });
            response.VehicleModel = await _readGenericModelRepository.GetFirstAsync(x=>x.Id == advertisement!.VehicleModelId, x => new VehicleModel { Id = x.Id, Name = x.Name });
            response.Name = response.VehicleBrand.Name + " " + response.VehicleModel.Name;
            return response;
        }
    }
}
