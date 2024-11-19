namespace WebCar.Domain.Models
{
    public class TransmissionType
    {
        public TransmissionTypeEnum Id { get; private set; }  // Enum como chave primária
        public string Name { get; private set; } // Nome derivado do Enum

        private TransmissionType() { } // Construtor para o EF

        public TransmissionType(TransmissionTypeEnum id)
        {
            Id = id;
            Name = id.ToString();  // O nome será o nome do valor do enum
        }
    }

    public enum TransmissionTypeEnum
    {
        Manual = 1,
        Automatic = 2,
        SemiAutomatic = 3
    }
}
