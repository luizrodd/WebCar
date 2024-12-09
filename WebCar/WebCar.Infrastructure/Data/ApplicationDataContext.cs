using Microsoft.EntityFrameworkCore;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }

        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<CarOptionalType> Optionals { get; set; }
        public DbSet<PostHistory> PostHistories { get; set; }
        public DbSet<CarOptional> PostOptionals { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<Domain.Models.Version> Versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDataContext).Assembly);
        }
    }
}
