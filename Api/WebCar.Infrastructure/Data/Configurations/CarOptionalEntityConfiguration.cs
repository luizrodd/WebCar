using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class PostCarOptionalConfiguration : IEntityTypeConfiguration<CarOptional>
    {
        public void Configure(EntityTypeBuilder<CarOptional> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasOne<CarOptionalType>()
                 .WithMany()
                 .HasConstraintName("FK_CarOptional_CarOptionalType")
                 .HasForeignKey(_ => _.CarOptionalType)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .IsRequired();

            builder.Property(_ => _.CarOptionalType)
                .HasConversion(
                _ => (int)_,
                _ => (CarOptionalTypeEnum)_)
                .HasColumnName("CarOptionalTypeId")
                .IsRequired();
        }
    }
}
