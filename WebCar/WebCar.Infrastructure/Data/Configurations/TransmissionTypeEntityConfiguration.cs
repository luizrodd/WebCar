using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class TransmissionTypeEntityConfiguration : IEntityTypeConfiguration<TransmissionType>
    {
        public void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasConversion<int>()
                   .ValueGeneratedNever(); 

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasData(
                new { Id = TransmissionTypeEnum.Manual, Name = "Manual" },
                new { Id = TransmissionTypeEnum.Automatic, Name = "Automatic" },
                new { Id = TransmissionTypeEnum.SemiAutomatic, Name = "Semi-Automatic" }
                );
        }
    }
}
