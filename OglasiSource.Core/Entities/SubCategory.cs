using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Entities
{
    public class SubCategory : BaseEntity, ITrackable
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string LogoName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Advertisement> Advertisements { get; set; }
        public List<VehicleBrand> VehicleBrands { get; set; }
    }
}
