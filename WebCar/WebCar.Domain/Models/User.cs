using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class User : Entity<Guid>
    {
        private readonly List<Post> _posts;

        private User()
        {
            _posts = [];
        }

        public User(string email, string password, string name, string contact, UserTypeEnum userType) : this()
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Name = name;
            Contact = contact;
            UserType = userType;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Contact { get; private set; }
        public bool IsAdmin { get; private set; }
        public UserTypeEnum UserType { get; private set; }
        public IReadOnlyCollection<Post> Posts => _posts;
        public void AddPost(Post post)
        {
            _posts.Add(post);
        }
    }
}

public class UserType
{
    public UserTypeEnum Id { get; private set; }
    public string Name { get; private set; }
    public UserType(UserTypeEnum id)
    {
        Id = id;
        Name = id.ToString();
    }
}

public enum UserTypeEnum
{
    User = 0,
    Shop = 1
}
