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
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(i => i.Id)
                .IsRequired();

            builder.Property(i => i.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(i => i.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(i => i.ContentType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.FileSize)
                .IsRequired();

            builder.Property(i => i.CreatedAt)
                .IsRequired();
        }
    }
}
