using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(b => b.Models)
              .WithOne()
              .HasForeignKey("BrandId")
              .OnDelete(DeleteBehavior.Cascade); 

            builder.Navigation(b => b.Models)
                   .UsePropertyAccessMode(PropertyAccessMode.Field); 
        }
    }
}
