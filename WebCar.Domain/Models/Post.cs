namespace WebCar.Domain.Models
{
    public class Post
    {
        public Post(long kilometer, int yearOfManufacture, int yearOfModel, decimal price, string localization, 
            string description, bool armored, bool IPVa, bool acceptTrade, bool licensed,
            bool used, ClutchTypeEnum clutch, FuelTypeEnum fuel, BodyTypeEnum body, 
            Version version)
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

            Clutch            = clutch;
            Fuel              = fuel;
            Body              = body;
            Version           = version;

            CreatedAt         = DateTime.UtcNow;
            UpdatedAt         = DateTime.UtcNow;
        }

        public long Kilometer { get; private set; }
        public int YearOfManufacture { get; private set; }
        public int YearOfModel { get; private set; }
        public decimal Price { get; private set; }
        public string Localization { get; private set; }
        public string Description { get; private set; }
        public bool IsSold { get; private set; }
        public bool IsArmored { get; private set; }
        public bool IPVA { get; private set; }
        public bool AcceptTrade { get; private set; }
        public bool IsLicensed { get; private set; }
        public bool IsUsed { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public ClutchTypeEnum Clutch { get; private set; }
        public FuelTypeEnum Fuel { get; private set; }
        public BodyTypeEnum Body { get; private set; }
        public Version Version { get; private set; }
        public ICollection<PostOptional?> Optionals { get; private set; }  = new List<PostOptional?>();
        public ICollection<Image?> Images { get; private set; } = new List<Image?>();

        public void Sold()
        {
            IsSold = true;
            UpdatedAt = DateTime.Now;
        }

        public void AddOptional(PostOptional optional)
        {
            Optionals.Add(optional);
            UpdatedAt = DateTime.Now;
        }

        public void AddImage(Image image)
        {
            Images.Add(image);
            UpdatedAt = DateTime.Now;
        }
    }
}
