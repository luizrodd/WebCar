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

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.AcceptTrade)
                .IsRequired();

            builder.Property(x => x.Localization)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(256);

            builder.HasOne(x => x.Car)
                .WithOne()
                .HasForeignKey<Post>("CarId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Post_Car")
                .IsRequired();

            builder.HasOne<PostStatus>()
                .WithMany()
                .HasConstraintName("FK_Post_PostStatus")
                .HasForeignKey(_ => _.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();

            builder.Property(_ => _.Status)
                .HasConversion(
                _ => (int)_,
                _ => (PostStatusEnum)_)
                .HasColumnName("PostStatusId")
                .IsRequired();

            builder.HasMany(_ => _.Histories)
                .WithOne()
                .IsRequired()
                .HasForeignKey("PostId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PostHistory_Post");

            builder.OwnsMany(_ => _.Images,
                sa =>
                {
                    sa.Property(typeof(Guid), "Id")
                        .HasColumnType("uniqueidentifier")
                        .ValueGeneratedOnAdd();

                    sa.Property(x => x.Filename)
                        .IsRequired()
                        .IsUnicode(true)
                        .HasMaxLength(256);

                    sa.Property(e => e.ScannedFileId)
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");
                });
        }
    }
}
