
using System.ComponentModel.DataAnnotations.Schema;

namespace OglasiSource.Core.Entities
{
    public class Review : BaseEntity, ITrackable
    {
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int EntityTypeReviewId { get; set; }
        public EntityTypeReview EntityTypeReview { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string Comment { get; set; }
        public int EntityTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
