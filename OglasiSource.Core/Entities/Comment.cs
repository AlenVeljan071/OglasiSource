using System.ComponentModel.DataAnnotations.Schema;

namespace OglasiSource.Core.Entities

{
    public class Comment : BaseEntity, ITrackable
    {
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int EntityTypeCommentId { get; set; }
        public EntityTypeComment EntityTypeComment { get; set; }
        public int EntityTypeId { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
