using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class OptionalTypeEntityConfiguration : IEntityTypeConfiguration<OptionalType>
    {
        public void Configure(EntityTypeBuilder<OptionalType> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasConversion<int>()
                   .ValueGeneratedNever();

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
