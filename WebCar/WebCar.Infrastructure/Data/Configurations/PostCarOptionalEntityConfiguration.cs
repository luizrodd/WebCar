using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class PostCarOptionalConfiguration : IEntityTypeConfiguration<PostCarOptional>
    {
        public void Configure(EntityTypeBuilder<PostCarOptional> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasOne<CarOptionalType>()
                 .WithMany()
                 .HasConstraintName("FK_PostCarOptional_CarOptionalType")
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
