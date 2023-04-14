using OglasiSource.Core.Helpers;

namespace OglasiSource.Core.Responses.Advertisements
{
    public class AdvertisementListResponse
    {
        public Pagination<AdvertisementMinResponse> Pagination { get; set; }
    }
}
