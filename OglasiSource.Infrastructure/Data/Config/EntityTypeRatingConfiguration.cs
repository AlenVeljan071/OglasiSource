﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OglasiSource.Core.Entities;

namespace OglasiSource.Infrastructure.Data.Config
{
    public class EntityTypeRatingConfiguration : IEntityTypeConfiguration<EntityTypeRating>
    {
        public void Configure(EntityTypeBuilder<EntityTypeRating> builder)
        {
            builder.HasIndex(x => new { x.Name }).IsUnique();
            builder.HasData(
                new EntityTypeReview { Id = 1, Name = "User" },
                new EntityTypeRating { Id = 2, Name = "Comment" }
                );
        }
    }
}
