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
    public class CarConditionTypeEntityConfiguration : IEntityTypeConfiguration<CarConditionType>
    {
        public void Configure(EntityTypeBuilder<CarConditionType> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasConversion<int>()
                   .ValueGeneratedNever();

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasData(
                new { Id = CarConditionTypeEnum.New, Name = "New" },
                new { Id = CarConditionTypeEnum.Used, Name = "Used" },
                new { Id = CarConditionTypeEnum.SemiNew, Name = "SemiNew" }
                );
        }
    }
}
