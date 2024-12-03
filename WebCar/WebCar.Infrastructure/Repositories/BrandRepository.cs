using Microsoft.EntityFrameworkCore;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;
using WebCar.Infrastructure.Data;

namespace WebCar.Infrastructure.Repositories
{
    public class BrandRepository : BaseRepository<Brand, Guid>, IBrandRepository
    {
        public BrandRepository(ApplicationDataContext context) : base(context)
        {
        }

        public override IQueryable<Brand> GetAll()
        {
            return _entity
                .Include(x => x.Models).ThenInclude(x => x.Versions);
             
        }
    }
}
