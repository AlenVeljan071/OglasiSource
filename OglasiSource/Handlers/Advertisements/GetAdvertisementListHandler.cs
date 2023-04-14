using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Queries.Advertisement;
using OglasiSource.Core.Helpers;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Core.Responses.Advertisements;
using OglasiSource.Core.Specifications.Advertisement;

namespace OglasiSource.Api.Handlers.Advertisements
{
    public class GetAdvertisementListHandler : IRequestHandler<GetAdvertisementsListQuery, AdvertisementListResponse>
    {
        private readonly IReadGenericRepository<Core.Entities.Advertisement> _readGenericRepository;
        private readonly IMapper _mapper;

        public GetAdvertisementListHandler(IReadGenericRepository<Core.Entities.Advertisement> readGenericRepository, IMapper mapper)
        {
            _readGenericRepository = readGenericRepository;
            _mapper = mapper;
        }
        public async Task<AdvertisementListResponse> Handle(GetAdvertisementsListQuery request, CancellationToken cancellationToken)
        {
            var totalItems = await _readGenericRepository.CountAsync(new AdvertisementCountSpecification(request.AdvertisementSpecParams));
            var advertisements = await _readGenericRepository.ListAsync(new AdvertisementSpecification(request.AdvertisementSpecParams));
            var advertisementsResponse = _mapper.Map<IReadOnlyList<AdvertisementMinResponse>>(advertisements);

            return new AdvertisementListResponse
            {
                Pagination = new Pagination<AdvertisementMinResponse>(request.AdvertisementSpecParams.PageIndex, request.AdvertisementSpecParams.PageSize, totalItems, advertisementsResponse),
            };
        }
    }
}
