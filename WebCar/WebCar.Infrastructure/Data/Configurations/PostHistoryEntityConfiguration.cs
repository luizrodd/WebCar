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
    internal class PostHistoryEntityConfiguration : IEntityTypeConfiguration<PostHistory>
    {
        public void Configure(EntityTypeBuilder<PostHistory> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(256);

            builder.Property(x => x.CreatedBy)
                .IsRequired();
        }
    }
}
