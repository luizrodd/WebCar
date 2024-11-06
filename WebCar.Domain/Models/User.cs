namespace WebCar.Domain.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        public void AddFavorite(Favorite favorite)
        {
            Favorites.Add(favorite);
        }
    }
}
