using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class PostStatusEntityConfiguration : IEntityTypeConfiguration<PostStatus>
    {
        public void Configure(EntityTypeBuilder<PostStatus> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasConversion<int>()
                   .ValueGeneratedNever();

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasData(
              new { Id = PostStatusEnum.Pendent, Name = "Pendent" },
              new { Id = PostStatusEnum.Available, Name = "Available" },
              new { Id = PostStatusEnum.Sold, Name = "Sold" },
              new { Id = PostStatusEnum.Canceled, Name = "Canceled" }
            );
        }
    }
}
