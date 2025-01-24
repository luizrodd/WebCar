using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class BodyTypeEntityConfiguration : IEntityTypeConfiguration<BodyType>
    {
        public void Configure(EntityTypeBuilder<BodyType> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasConversion<int>()
                   .ValueGeneratedNever();

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasData(
                new { Id = BodyTypeEnum.Sedan, Name = "Sedan" },
                new { Id = BodyTypeEnum.Coupe, Name = "Coupe" },
                new { Id = BodyTypeEnum.Hatchback, Name = "Hatchback" },
                new { Id = BodyTypeEnum.SUV, Name = "SUV" },
                new { Id = BodyTypeEnum.Pickup, Name = "Pickup" },
                new { Id = BodyTypeEnum.Convertible, Name = "Convertible" },
                new { Id = BodyTypeEnum.Minivan, Name = "Minivan" },
                new { Id = BodyTypeEnum.Van, Name = "Van" }
                );
        }
    }
}
