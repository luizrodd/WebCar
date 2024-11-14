namespace WebCar.Domain.Models
{
    public class User
    {
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
