using Microsoft.EntityFrameworkCore;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }

        public DbSet<BodyType> BodyType { get; set; }
        public DbSet<TransmissionType> TransmissionType { get; set; }
        public DbSet<CarConditionType> ConditionType { get; set; }
        public DbSet<CarOptionalType> Optionals { get; set; }
        public DbSet<FuelType> FuelType { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Domain.Models.Version> Versions { get; set; }
        public DbSet<PostStorage> PostStorage { get; set; }
        public DbSet<PostHistory> PostHistories { get; set; }
        public DbSet<CarOptional> CarOptionals { get; set; }
        public DbSet<PostStatus> PostStatus { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDataContext).Assembly);
        }
    }
}
