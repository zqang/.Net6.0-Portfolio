namespace PortfolioAPI.Models
{
    public class Author
    {
        public Author(Guid authorId, Guid userId, string name, string bio) 
        { 
            AuthorID = authorId;
            UserID = userId;
            Name = name;
            Bio = bio;
        }


        public Guid AuthorID { get; set; } // Primary Key
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }

        public User User { get; set; }
        public ICollection<Post> Posts { get; } = new List<Post>();
    }
}
