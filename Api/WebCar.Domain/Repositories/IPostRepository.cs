
using WebCar.Domain.Models.PostAggregate;

namespace WebCar.Domain.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
    }
}
