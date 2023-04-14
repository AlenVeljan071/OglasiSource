using System.ComponentModel.DataAnnotations.Schema;

namespace OglasiSource.Core.Entities
{
    public class SavedImage : BaseEntity, ITrackable
    {
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
