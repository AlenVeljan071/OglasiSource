using System.ComponentModel.DataAnnotations.Schema;

namespace OglasiSource.Core.Entities
{
    public class EntityTypeRating : BaseEntity, ITrackable
    {
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
