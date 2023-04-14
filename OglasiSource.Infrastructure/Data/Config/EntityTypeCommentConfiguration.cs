using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OglasiSource.Core.Entities;

namespace MyPersonalTrainer.Infrastructure.Data.Config
{
    public class EntityTypeCommentConfiguration : IEntityTypeConfiguration<EntityTypeComment>
    {

        public void Configure(EntityTypeBuilder<EntityTypeComment> builder)

        {

            builder.HasIndex(x => new { x.Name }).IsUnique();

            //builder.HasData(

            //    new EntityTypeComment { Id = 1, Name = "Training" },
            //    new EntityTypeComment { Id = 2, Name = "Program" },
            //    new EntityTypeComment { Id = 3, Name = "Nutrition" }
              

            //    );


        }
    }
}
