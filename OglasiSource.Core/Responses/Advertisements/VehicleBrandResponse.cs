using OglasiSource.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Responses.Advertisements
{
    public class VehicleBrandResponse
    {
        public int Id { get; set; }
        public int SubcategoryId { get; set; } 
        public string Name { get; set; }
    }
}
