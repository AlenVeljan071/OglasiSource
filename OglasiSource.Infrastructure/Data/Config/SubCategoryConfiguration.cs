using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Infrastructure.Data.Config
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasOne(x => x.Category)
                  .WithMany(x => x.SubCategories)
                  .HasForeignKey(x => x.CategoryId)
                  .IsRequired();



            builder.HasData(
              new SubCategory { Id = 1, Name = "Cars", CategoryId = 1, LogoName = "cars.svg" },
              new SubCategory { Id = 2, Name = "Motorcycles", CategoryId = 1, LogoName = "cars.svg" },
              new SubCategory { Id = 3, Name = "Cargo vehicles", CategoryId = 1, LogoName = "cars.svg" }
            );

        }
    }
}
