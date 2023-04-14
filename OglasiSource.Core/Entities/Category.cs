using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Entities
{
    public class Category : BaseEntity, ITrackable
    {
        public string Name { get; set; }
        public string LogoName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<SubCategory> SubCategories { get; set; }

    }
}
