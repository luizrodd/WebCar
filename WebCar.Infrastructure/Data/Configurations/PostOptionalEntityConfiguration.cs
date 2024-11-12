using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations
{
    public class PostOptionalConfiguration : IEntityTypeConfiguration<PostOptional>
    {
        public void Configure(EntityTypeBuilder<PostOptional> builder)
        {
        }
    }
}
