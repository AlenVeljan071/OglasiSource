namespace OglasiSource.Core.Specifications.Advertisement
{
    public class AdvertisementCountSpecification : BaseSpecification<Entities.Advertisement>
    {
        public AdvertisementCountSpecification(AdvertisementSpecParams specParams) : base(x =>
            (string.IsNullOrEmpty(specParams.Search1) || (x.VehicleBrand!.Name.ToLower().Contains(specParams.Search1))) &&
            (string.IsNullOrEmpty(specParams.Search2) || (x.VehicleBrand!.Name.ToLower().Contains(specParams.Search2))) &&
            (string.IsNullOrEmpty(specParams.Search) || (x.VehicleBrand!.Name.ToLower().Contains(specParams.Search)))
          )
        {

        }
    }
}
