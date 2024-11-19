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

        public User(string email, string password, string name, string contact, UserTypeEnum userType)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Name = name;
            Contact = contact;
            UserType = userType;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public UserTypeEnum UserType { get; set; }
        public IReadOnlyCollection<Post> Posts => _posts;
        public void AddPost(Post post){
            _posts.Add(post);
        }
    }

    public class UserType{
        public UserTypeEnum Id { get; set; }
        public string Name {get; set; }
        public UserType(UserTypeEnum id){
            Id = id;
            Name = id.ToString();
        }
    }

    public enum UserTypeEnum{
        User = 0,
        Shop = 1
    }
}
