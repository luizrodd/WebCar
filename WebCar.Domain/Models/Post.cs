using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class Post : Entity<Guid>
    {   
        List<PostOptional> _optionalPosts;
        List<Image> _images;
        private Post()
        {
            _optionalPosts = new List<PostOptional>();
            _images = new List<Image>();
        }
        public Post(long kilometer, int yearOfManufacture, int yearOfModel, decimal price, string localization, 
            string description, bool armored, bool IPVa, bool acceptTrade, bool licensed,
            bool used, TransmissionTypeEnum clutch, FuelTypeEnum fuel, BodyTypeEnum body, 
            Version version, List<Image> images, List<PostOptional> postOptionals)
        {
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
            Version           = version;

            CreatedAt         = DateTime.UtcNow;
            UpdatedAt         = DateTime.UtcNow;

            _optionalPosts = postOptionals;
            _images = images;
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
        public IReadOnlyCollection<PostOptional> Optionals => _optionalPosts;
        public IReadOnlyCollection<Image> Images => _images;

        public void Sold()
        {
            IsSold = true;
            UpdatedAt = DateTime.Now;
        }
    }
}
