using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglasiSource.Core.Entities
{
    [Owned]
    public class AddressEntity
    {
        [Column(TypeName = "varchar(50)")]
        public string? City { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? County { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Address { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string? Country { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? ZipCode { get; set; }

    }
}
