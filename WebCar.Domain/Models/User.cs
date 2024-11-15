using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class User : Entity<Guid>
    {
        public User(string email, string password, string name, string phoneNumber, string contact, UserTypeEnum userType)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            Contact = contact;
            UserType = userType;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Contact { get; set; }
        public UserTypeEnum UserType { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public void AddPost(Post post){
            Posts.Add(post);
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
