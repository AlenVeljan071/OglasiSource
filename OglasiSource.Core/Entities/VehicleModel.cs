using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Entities
{
    public class VehicleModel : BaseEntity, ITrackable
    {
        public int VehicleBrandId { get; set; }
        public VehicleBrand VehicleBrand { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Advertisement> Advertisements { get; set; }

    }
}
