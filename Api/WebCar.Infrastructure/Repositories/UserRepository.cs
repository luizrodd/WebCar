using WebCar.Domain.Models;
using WebCar.Domain.Repositories;
using WebCar.Infrastructure.Data;

namespace WebCar.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDataContext context) : base(context)
        {
        }
    }
}
