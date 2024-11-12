namespace WebCar.Domain.Models
{
    public class PostHistory
    {
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public string Description { get; private set; }
        public PostHistory(string description, string createdBy)
        {
            CreatedAt = DateTime.Now;
            CreatedBy = createdBy;
            Description = description;  
        }
    }
}