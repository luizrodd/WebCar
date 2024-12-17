using WebCar.Domain.Core;
using WebCar.Domain.Interfaces;

namespace WebCar.Domain.Models
{
    public class Post : Entity<Guid>
    {   
        private readonly List<PostStorage> _images;
        private readonly List<PostHistory> _histories;
        private Post()
        {
            _images = [];
            _histories = [];
        }
        public Post(
            Guid userId,
            decimal price, 
            string localization, 
            string description,
            bool acceptTrade,
            Car car,
            List<ImageDraft> images,
            IFileManagerService imageService
            ) : this()
        {
            Id = Guid.NewGuid();
            UserId            = userId;
            Price             = price;
            Localization      = localization;
            Description       = description;
            Car               = car;

            Status            = PostStatusEnum.Pendent;
            AcceptTrade       = acceptTrade;

            CreatedAt         = DateTime.UtcNow;
            UpdatedAt         = DateTime.UtcNow;

            AddImages(images, imageService);

            _histories.Add(new PostHistory("Post created", "System"));
        }

        public decimal Price { get; private set; }
        public string Localization { get; private set; }
        public string? Description { get; private set; }
        public bool AcceptTrade { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Guid UserId { get; private set; }

        public Car Car { get; private set; }
        public PostStatusEnum Status { get; private set; }
        public IReadOnlyCollection<PostStorage> Images => _images;
        public IReadOnlyCollection<PostHistory> Histories => _histories;
        public void AddImages(List<ImageDraft> imagesDraft, IFileManagerService imageService) 
        {
            foreach (var image in imagesDraft)
            {
                var id = imageService.Save(this.UserId, this.Id, image.FileName, image.Data);
                _images.Add(new PostStorage(image.FileName, id));
            }
        }
    }
}