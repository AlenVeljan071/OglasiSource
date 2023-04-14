using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OglasiSource.Core.Entities;

namespace OglasiSource.Infrastructure.Data.Config
{
    public class VehicleBrandConfiguration : IEntityTypeConfiguration<VehicleBrand>
    {
        public void Configure(EntityTypeBuilder<VehicleBrand> builder)
        {
            builder.HasMany(x => x.VehicleModels)
               .WithOne(x => x.VehicleBrand)
               .HasForeignKey(x => x.VehicleBrandId!);

            builder.HasData(
               new VehicleBrand { Id = 1, Name = "Alfa Romeo", SubcategoryId = 1 },
               new VehicleBrand { Id = 2, Name = "Audi", SubcategoryId = 1 },
               new VehicleBrand { Id = 3, Name = "BMW", SubcategoryId = 1 },
               new VehicleBrand { Id = 4, Name = "Citroen", SubcategoryId = 1 },
               new VehicleBrand { Id = 5, Name = "Dacia", SubcategoryId = 1 },
               new VehicleBrand { Id = 6, Name = "Fiat", SubcategoryId = 1 },
               new VehicleBrand { Id = 7, Name = "Ford", SubcategoryId = 1 },
               new VehicleBrand { Id = 8, Name = "Hyundai", SubcategoryId = 1 },
               new VehicleBrand { Id = 9, Name = "Jeep", SubcategoryId = 1 },
               new VehicleBrand { Id = 10, Name = "Kia", SubcategoryId = 1 },
               new VehicleBrand { Id = 11, Name = "Mazda", SubcategoryId = 1 },
               new VehicleBrand { Id = 12, Name = "Mercedes-Benz", SubcategoryId = 1 },
               new VehicleBrand { Id = 13, Name = "Mitsubishi", SubcategoryId = 1 },
               new VehicleBrand { Id = 14, Name = "Nissan", SubcategoryId = 1 },
               new VehicleBrand { Id = 15, Name = "Opel", SubcategoryId = 1 },
               new VehicleBrand { Id = 16, Name = "Peugeot", SubcategoryId = 1 },
               new VehicleBrand { Id = 17, Name = "Renault", SubcategoryId = 1 },
               new VehicleBrand { Id = 18, Name = "Seat", SubcategoryId = 1 },
               new VehicleBrand { Id = 19, Name = "Škoda", SubcategoryId = 1 },
               new VehicleBrand { Id = 20, Name = "Suzuki", SubcategoryId = 1 },
               new VehicleBrand { Id = 21, Name = "Toyota", SubcategoryId = 1 },
               new VehicleBrand { Id = 22, Name = "VolksWagen", SubcategoryId = 1 },
               new VehicleBrand { Id = 23, Name = "Volvo", SubcategoryId = 1 },
               new VehicleBrand { Id = 24, Name = "Land Rover", SubcategoryId = 1 },
               new VehicleBrand { Id = 25, Name = "Lada", SubcategoryId = 1 },
               new VehicleBrand { Id = 26, Name = "Aston Martin", SubcategoryId = 1 },
               new VehicleBrand { Id = 27, Name = "Bentley", SubcategoryId = 1 },
               new VehicleBrand { Id = 28, Name = "Bugatti", SubcategoryId = 1 },
               new VehicleBrand { Id = 29, Name = "Buick", SubcategoryId = 1 },
               new VehicleBrand { Id = 30, Name = "Cadillac", SubcategoryId = 1 },
               new VehicleBrand { Id = 31, Name = "Caterham", SubcategoryId = 1 },
               new VehicleBrand { Id = 32, Name = "Chevrolet", SubcategoryId = 1 },
               new VehicleBrand { Id = 33, Name = "Chrysler", SubcategoryId = 1 },
               new VehicleBrand { Id = 34, Name = "Cupra", SubcategoryId = 1 },
               new VehicleBrand { Id = 35, Name = "Daewoo", SubcategoryId = 1 },
               new VehicleBrand { Id = 36, Name = "Daihatsu", SubcategoryId = 1 },
               new VehicleBrand { Id = 37, Name = "Dodge", SubcategoryId = 1 },
               new VehicleBrand { Id = 38, Name = "Ferrari", SubcategoryId = 1 },
               new VehicleBrand { Id = 39, Name = "GMC", SubcategoryId = 1 },
               new VehicleBrand { Id = 40, Name = "Hummer", SubcategoryId = 1 },
               new VehicleBrand { Id = 41, Name = "Infiniti", SubcategoryId = 1 },
               new VehicleBrand { Id = 42, Name = "Jaguar", SubcategoryId = 1 },
               new VehicleBrand { Id = 43, Name = "Lexus", SubcategoryId = 1 },
               new VehicleBrand { Id = 44, Name = "Maserati", SubcategoryId = 1 },
               new VehicleBrand { Id = 45, Name = "Maybach", SubcategoryId = 1 },
               new VehicleBrand { Id = 46, Name = "MINI", SubcategoryId = 1 },
               new VehicleBrand { Id = 47, Name = "Saab", SubcategoryId = 1 },
               new VehicleBrand { Id = 48, Name = "Smart", SubcategoryId = 1 },
               new VehicleBrand { Id = 49, Name = "Tesla", SubcategoryId = 1 },
               new VehicleBrand { Id = 50, Name = "Zastava", SubcategoryId = 1 }
           );
        }
    }
}
