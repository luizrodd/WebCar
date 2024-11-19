using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class VersionEntityConfiguration : IEntityTypeConfiguration<Domain.Models.Version>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Version> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
