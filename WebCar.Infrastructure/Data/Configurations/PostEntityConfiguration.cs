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

            builder.HasOne<FuelType>()
                .WithMany()
                .HasConstraintName("FK_Post_FuelType")
                .HasForeignKey(_ => _.FuelType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();

            builder.Property(_ => _.FuelType)
                .HasConversion(
                _ => (int)_,
                _ => (FuelTypeEnum)_)
                .HasColumnName("FuelTypeId")
                .IsRequired();

            builder.HasOne<TransmissionType>()
                .WithMany()
                .HasConstraintName("FK_Post_TransmissionType")
                .HasForeignKey(_ => _.TransmissionType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();

            builder.Property(_ => _.TransmissionType)
                .HasConversion(
                _ => (int)_,
                _ => (TransmissionTypeEnum)_)
                .HasColumnName("TransmissionTypeId")
                .IsRequired();

            builder.HasOne<BodyType>()
                .WithMany()
                .HasConstraintName("FK_Post_BodyType")
                .HasForeignKey(_ => _.BodyType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();

            builder.Property(_ => _.BodyType)
                .HasConversion(
                _ => (int)_,
                _ => (BodyTypeEnum)_)
                .HasColumnName("BodyTypeId")
                .IsRequired();

            builder.HasMany(_ => _.Images)
                .WithOne()
                .IsRequired()
                .HasForeignKey("PostId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Image_Post");

            builder.HasMany(_ => _.Optionals)
                .WithOne()
                .IsRequired()
                .HasForeignKey("PostId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PostOptional_Post");

            builder.HasMany(_ => _.Histories)
                .WithOne()
                .IsRequired()
                .HasForeignKey("PostId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PostHistory_Post");

            builder
                .Property<Guid>("_versionId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("VersionId")
                .IsRequired();

            builder.Ignore(x => x.Version)
                .HasOne(_ => _.Version)
                .WithMany()
                .HasForeignKey("_versionId")
                .HasConstraintName("FK_Post_Version");
        }
    }
}
