namespace PortfolioAPI.Models
{
    public class Author
    {
        public int AuthorID { get; set; } // Primary Key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }

        public ICollection<Post> Posts { get; } = new List<Post>();
    }
}
