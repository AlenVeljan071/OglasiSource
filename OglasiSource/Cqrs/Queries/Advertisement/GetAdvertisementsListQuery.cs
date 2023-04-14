using MediatR;
using OglasiSource.Core.Responses.Advertisements;
using OglasiSource.Core.Specifications.Advertisement;

namespace OglasiSource.Api.Cqrs.Queries.Advertisement
{
    public class GetAdvertisementsListQuery : IRequest<AdvertisementListResponse>
    {
        public AdvertisementSpecParams AdvertisementSpecParams { get; set; }
    }
}
