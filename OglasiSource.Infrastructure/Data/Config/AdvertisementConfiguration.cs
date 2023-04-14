using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OglasiSource.Core.Entities;

namespace OglasiSource.Infrastructure.Data.Config
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasOne(x => x.SubCategory)
                 .WithMany(x => x.Advertisements)
                 .HasForeignKey(x => x.SubCategoryId)
                 .IsRequired();

            builder.HasOne(x => x.VehicleBrand)
               .WithMany(x => x.Advertisements)
               .HasForeignKey(x => x.VehicleBrandId)
               .IsRequired();

            builder.HasOne(x => x.VehicleModel)
               .WithMany(x => x.Advertisements)
               .HasForeignKey(x => x.VehicleModelId)
               .IsRequired();

            builder.HasMany(x => x.SavedImages)
              .WithOne(x => x.Advertisement)
              .HasForeignKey(x => x.AdvertisementId)
              .IsRequired();

            builder.Property(x=>x.Price).HasPrecision(14,2);
            builder.OwnsOne(x => x.Address);

            builder.Property(x => x.Mileage).HasPrecision(14, 2);
            builder.OwnsOne(x => x.Address);
        }
    }
}
