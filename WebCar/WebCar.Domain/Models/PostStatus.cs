namespace WebCar.Domain.Models
{
    public class PostStatus
    {
        public PostStatusEnum Id { get; private set; }
        public string Name { get; private set; }

        public PostStatus(PostStatusEnum id)
        {
            Id = id;
            Name = id.ToString();
        }
    }

    public enum PostStatusEnum
    {
        Pendent = 0,
        Available = 1,
        Sold = 2,
        Canceled = 3
    }
}
