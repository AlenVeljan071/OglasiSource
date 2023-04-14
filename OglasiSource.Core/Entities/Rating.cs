namespace OglasiSource.Core.Entities
{
    public class Rating : BaseEntity, ITrackable
    {
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int EntityTypeRatingId { get; set; }
        public EntityTypeRating EntityTypeRating { get; set; }
        public int Thumb { get; set; }
        public int EntityTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
