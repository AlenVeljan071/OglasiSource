using MediatR;
using OglasiSource.Api.Cqrs.Queries.Advertisement;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Enums;
using OglasiSource.Core.Responses.Advertisements;

namespace OglasiSource.Api.Handlers.Advertisements
{
    public class GetAdvertisementModalHandler : IRequestHandler<GetAdvertisementModalQuery, GetAdvertisementModalResponse>
    {
        public GetAdvertisementModalHandler()
        {
            
        }

        public async Task<GetAdvertisementModalResponse> Handle(GetAdvertisementModalQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAdvertisementModalResponse
            {
                Colors = DictionaryExtensions.GetValues(Constants.Colors),
                Fuels = EnumExtensions.GetValues<Fuel>(),
                Shifters = DictionaryExtensions.GetValues(Constants.Shifters),
                Gears = DictionaryExtensions.GetValues(Constants.Gears),
                Emissions = DictionaryExtensions.GetValues(Constants.Emissions),
                Seats = DictionaryExtensions.GetValues(Constants.Emissions)
            };

            return await Task.FromResult(response);
        }
    }
}
