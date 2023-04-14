using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OglasiSource.Core.Entities;

namespace OglasiSource.Infrastructure.Data.Config
{
    public class EntityTypeReviewConfiguration : IEntityTypeConfiguration<EntityTypeReview>
    {
        public void Configure(EntityTypeBuilder<EntityTypeReview> builder)
        {
            builder.HasIndex(x => new { x.Name }).IsUnique();
            builder.HasData(
                new EntityTypeReview { Id = 1, Name = "User" }
                );
        }
    }

}

