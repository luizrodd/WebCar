using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class Post : Entity<Guid>
    {   
        private readonly List<PostCarOptional> _optionalPosts;
        private readonly List<Image> _images;
        private readonly List<PostHistory> _histories;
        private Post()
        {
            _optionalPosts = [];
            _images = [];
            _histories = [];
        }
        public Post(long kilometer, int yearOfManufacture, int yearOfModel, decimal price, string localization, 
            string description, bool armored, bool IPVa, bool acceptTrade, bool licensed,
            bool used, TransmissionTypeEnum clutch, FuelTypeEnum fuel, BodyTypeEnum body, 
            Guid versionId, List<Image> images, List<PostCarOptional> postOptionals) : this()
        {
            Id = Guid.NewGuid();
            Kilometer         = kilometer;
            YearOfManufacture = yearOfManufacture;
            YearOfModel       = yearOfModel;
            Price             = price;
            Localization      = localization;
            Description       = description;
            IsSold            = false;
            IsArmored         = armored;
            IPVA              = IPVa;
            AcceptTrade       = acceptTrade;
            IsLicensed        = licensed;
            IsUsed            = used;

            TransmissionType  = clutch;
            FuelType          = fuel;
            BodyType          = body;
            _versionId        = versionId;

            CreatedAt         = DateTime.UtcNow;
            UpdatedAt         = DateTime.UtcNow;

            _optionalPosts = postOptionals;
            _images = images;

            _histories.Add(new PostHistory("Post created", "System"));
        }

        public long Kilometer { get; private set; }
        public int YearOfManufacture { get; private set; }
        public int YearOfModel { get; private set; }
        public decimal Price { get; private set; }
        public string Localization { get; private set; }
        public string? Description { get; private set; }
        public bool IsSold { get; private set; }
        public bool IsArmored { get; private set; }
        public bool IPVA { get; private set; }
        public bool AcceptTrade { get; private set; }
        public bool IsLicensed { get; private set; }
        public bool IsUsed { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public TransmissionTypeEnum TransmissionType { get; private set; }
        public FuelTypeEnum FuelType { get; private set; }
        public BodyTypeEnum BodyType { get; private set; }
        public Version Version { get; private set; }
        private Guid _versionId;
        public IReadOnlyCollection<PostCarOptional> Optionals => _optionalPosts;
        public IReadOnlyCollection<Image> Images => _images;
        public IReadOnlyCollection<PostHistory> Histories => _histories;
    }
}