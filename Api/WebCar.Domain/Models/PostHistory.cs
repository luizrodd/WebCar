using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class PostHistory : Entity<Guid>
    {
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public string Description { get; private set; }
        public PostHistory(string description, string createdBy)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            CreatedBy = createdBy;
            Description = description;  
        }
    }
}