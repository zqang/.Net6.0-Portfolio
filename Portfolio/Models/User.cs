namespace PortfolioAPI.Models
{
    public class User
    {
        public int UserID { get; set; } // Primary Key
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Encrypted
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }

        public ICollection<Reaction> Reactions { get; } = new List<Reaction>();
    }
}
