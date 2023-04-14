using OglasiSource.Core.Entities;
using OglasiSource.Core.Responses.Image;

namespace OglasiSource.Core.Responses.Advertisements
{
    public class AdvertisementMinResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Year { get; set; }
        public AddressEntity Address { get; set; }
        public ImageResponse? Image { get; set; }
    }
}
