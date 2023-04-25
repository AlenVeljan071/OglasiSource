using OglasiSource.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglasiSource.Core.Entities
{
    public class ApplicationUser : BaseEntity, ITrackable
    {
        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? LastName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Password { get; set; }
        [Required]
        public AddressEntity? Address { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Salt { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Phone { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Code { get; set; }
        public UserType UserType { get; set; }
        public DateTime? CodeExpiration { get; set; }
        public int? UserCode { get; set; }
        public DateTime? UserCodeExpiration { get; set; }
        public bool Verified { get; set; }
        public byte[]? Avatar { get; set; }
        public int UpCount { get; set; }
        public int DownCount { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public List<Review> Reviews { get; set; }
        public List<Rating> Ratings { get; set; }

    }
}
