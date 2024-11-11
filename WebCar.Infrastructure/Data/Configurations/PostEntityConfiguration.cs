using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    internal class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.Property(x => x.Kilometer)
                .IsRequired();

            builder.Property(x => x.YearOfManufacture)
                .IsRequired();

            builder.Property(x => x.YearOfModel)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.IsLicensed)
                .IsRequired();

            builder.Property(x => x.IsUsed)
                .IsRequired();

            builder.Property(x => x.IsArmored)
                .IsRequired();

            builder.Property(x => x.IPVA)
                .IsRequired();

            builder.Property(x => x.AcceptTrade)
                .IsRequired();

            builder.Property(x => x.IsSold)
                .IsRequired();

            builder.Property(x => x.Localization)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(256);
        }
    }
}
