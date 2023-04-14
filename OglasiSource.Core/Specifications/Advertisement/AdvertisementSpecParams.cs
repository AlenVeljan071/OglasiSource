namespace OglasiSource.Core.Specifications.Advertisement
{
    public class AdvertisementSpecParams : BaseSpecParams
    {
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public decimal? MileageFrom { get; set; }
        public decimal? MileageTo { get; set; }
    }
}
