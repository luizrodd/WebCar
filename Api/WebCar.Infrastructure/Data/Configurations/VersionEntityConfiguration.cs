using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class VersionEntityConfiguration : IEntityTypeConfiguration<Domain.Models.BrandAggregate.Version>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.BrandAggregate.Version> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
