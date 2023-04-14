using MediatR;
using OglasiSource.Core.Responses.Advertisements;

namespace OglasiSource.Api.Cqrs.Queries.Advertisement
{
    public class GetAdvertisementModalQuery  : IRequest<GetAdvertisementModalResponse>
    {
    }
}
