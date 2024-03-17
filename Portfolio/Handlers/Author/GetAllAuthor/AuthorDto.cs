namespace PortfolioAPI.Handlers.Author.GetAllAuthor
{
    public class AuthorDto
    {
        public Guid AuthorID { get; set; } // Primary Key
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
    }
}
