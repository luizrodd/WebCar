using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class User : Entity<Guid>
    {
        public User(string email, string password, string name, string contact)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Name = name;
            Contact = contact;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Contact { get; private set; }
        public bool IsAdmin { get; private set; }
    }
}
