using WebCar.Domain.Models;
using WebCar.Domain.Repositories;
using WebCar.Infrastructure.Data;

namespace WebCar.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post, Guid>, IPostRepository
    {
        public PostRepository(ApplicationDataContext context) : base(context)
        {
        }
    }
}
