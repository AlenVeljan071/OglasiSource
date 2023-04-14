using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;
using OglasiSource.Core.Responses;

namespace OglasiSource.Core.Responses.Comment
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public EnumValue EntityTypeComment { get; set; }
        public string CommentContent { get; set; }
        public int DownRatingCount { get; set; }
        public int UpRatingCount { get; set; }
        public int? CurrentCompanyUserRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
