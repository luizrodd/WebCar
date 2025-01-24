namespace WebCar.Domain.Models
{
    public class TransmissionType
    {
        public TransmissionTypeEnum Id { get; private set; }  
        public string Name { get; private set; } 

        private TransmissionType() { }

        public TransmissionType(TransmissionTypeEnum id)
        {
            Id = id;
            Name = id.ToString();  
        }
    }

    public enum TransmissionTypeEnum
    {
        Manual = 0,
        Automatic = 1,
        SemiAutomatic = 2
    }
}
