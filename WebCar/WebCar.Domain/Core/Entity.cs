namespace WebCar.Domain.Core
{
    public interface Entity
    {
    }

    public abstract class Entity<TKey> : Entity
    {
        public TKey Id { get; protected set; }
    }   
}
