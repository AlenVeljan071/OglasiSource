using OglasiSource.Core.Enums;

namespace OglasiSource.Core.Entities
{
    public class VehicleBrand : BaseEntity, ITrackable
    {
        public string Name { get; set; }
        public int SubcategoryId { get; set; }
        public SubCategory Subcategory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
        public List<Advertisement> Advertisements { get; set; }
    }
}
