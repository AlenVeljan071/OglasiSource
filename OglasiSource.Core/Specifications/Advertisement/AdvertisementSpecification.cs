using System.Security.Cryptography.X509Certificates;

namespace OglasiSource.Core.Specifications.Advertisement
{
    public class AdvertisementSpecification : BaseSpecification<Entities.Advertisement>
    {
        public AdvertisementSpecification(AdvertisementSpecParams specParams) : base(x =>
            (string.IsNullOrEmpty(specParams.Search1) || (x.VehicleBrand!.Name!.ToLower().Contains(specParams.Search1)) || (x.VehicleModel!.Name!.ToLower().Contains(specParams.Search1))) &&
            (string.IsNullOrEmpty(specParams.Search2) || (x.VehicleBrand!.Name!.ToLower().Contains(specParams.Search2)) || (x.VehicleModel!.Name!.ToLower().Contains(specParams.Search2))) &&
            (string.IsNullOrEmpty(specParams.Search) || (x.VehicleBrand!.Name!.ToLower().Contains(specParams.Search)) || (x.VehicleModel!.Name!.ToLower().Contains(specParams.Search))) &&
            (!specParams.ApplicationUserId.HasValue || specParams.ApplicationUserId == x.ApplicationUserId) &&
            (!specParams.PriceFrom.HasValue || (x.Price != null ? x.Price >= specParams.PriceFrom! : false)) &&
            (!specParams.PriceTo.HasValue || (x.Price != null ? x.Price <= specParams.PriceTo! : false)) &&
            (!specParams.MileageFrom.HasValue || (x.Mileage != null ? x.Mileage >= specParams.MileageFrom! : false)) &&
            (!specParams.MileageTo.HasValue || (x.Mileage != null ? x.Mileage <= specParams.MileageTo! : false)) 
          )
        {
            AddInclude(x => x.VehicleBrand!);
            AddInclude(x => x.VehicleModel!);
            AddInclude(x=>x.SavedImages);

            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);


        }
        public AdvertisementSpecification(int Id) : base(x =>
        (x.Id == Id))
        {
            AddInclude(x => x.SavedImages);
        }
    }
}
