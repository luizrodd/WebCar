using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Kilometer)
                .IsRequired();

            builder.Property(x => x.YearOfManufacture)
                .IsRequired();

            builder.Property(x => x.YearOfModel)
                .IsRequired();

            builder.Property(x => x.IsLicensed)
                .IsRequired();

            builder.Property(x => x.IsArmored)
                .IsRequired();

            builder.Ignore(x => x.Version)
                .HasOne(_ => _.Version)
                .WithMany()
                .HasForeignKey("_versionId")
                .HasConstraintName("FK_Post_Version");

            builder.Property<Guid>("_versionId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("VersionId")
                .IsRequired();

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

            builder.HasOne<CarConditionType>()
                .WithMany()
                .HasConstraintName("FK_Post_CarConditionType")
                .HasForeignKey(_ => _.ConditionType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();

            builder.Property(_ => _.ConditionType)
                .HasConversion(
                _ => (int)_,
                _ => (CarConditionTypeEnum)_)
                .HasColumnName("ConditionTypeId")
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

            builder.HasMany(_ => _.Optionals)
                .WithOne()
                .IsRequired()
                .HasForeignKey("CarId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CarOptional_Car");
        }
    }
}
