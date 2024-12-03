using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class FuelTypeEntityConfiguration : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasConversion<int>()
                   .ValueGeneratedNever();

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasData(
                new { Id = FuelTypeEnum.Diesel, Name = "Diesel" },
                new { Id = FuelTypeEnum.Electric, Name = "Electric" },
                new { Id = FuelTypeEnum.Flex, Name = "Flex" },
                new { Id = FuelTypeEnum.Gasoline, Name = "Gasoline" },
                new { Id = FuelTypeEnum.Hybrid, Name = "Hybrid" },
                new { Id = FuelTypeEnum.Alcohol, Name = "Alcohol" }
                );
        }
    }
}
