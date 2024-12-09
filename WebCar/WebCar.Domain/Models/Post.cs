using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class Post : Entity<Guid>
    {   
        private readonly List<Image> _images;
        private readonly List<PostHistory> _histories;
        private Post()
        {
            _images = [];
            _histories = [];
        }
        public Post(
            decimal price, 
            string localization, 
            string description,
            bool acceptTrade,
            List<Image> images, 
            List<CarOptional> postOptionals) : this()
        {
            Id = Guid.NewGuid();
            Price             = price;
            Localization      = localization;
            Description       = description;
            IsSold            = false;
            AcceptTrade       = acceptTrade;

            CreatedAt         = DateTime.UtcNow;
            UpdatedAt         = DateTime.UtcNow;

            _images = images;

            _histories.Add(new PostHistory("Post created", "System"));
        }

        public decimal Price { get; private set; }
        public string Localization { get; private set; }
        public string? Description { get; private set; }
        public bool IsSold { get; private set; }
        public bool AcceptTrade { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public IReadOnlyCollection<Image> Images => _images;
        public IReadOnlyCollection<PostHistory> Histories => _histories;
    }
}