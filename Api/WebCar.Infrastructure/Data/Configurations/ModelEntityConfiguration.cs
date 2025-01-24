using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    internal class ModelEntityConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(b => b.Versions)
              .WithOne()
              .HasForeignKey("ModelId")
              .HasConstraintName("FK_Model_Version")
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
