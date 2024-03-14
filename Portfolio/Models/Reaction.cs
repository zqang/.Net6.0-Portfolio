namespace PortfolioAPI.Models
{
    public class Reaction
    {
        public int ReactionID { get; set; } // Primary Key
        public int PostID { get; set; } // Foreign Key referencing Posts table
        public int UserID { get; set; } // Foreign Key referencing Users table
        public ReactionTypeEnum ReactionType { get; set; }
        public int ReactionAmounts { get; set; }
        public DateTime DateTime { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }

    }

    public enum ReactionTypeEnum
    {
        None = 0,
        Like,
        Dislike,
        Love,
        Interesting,
        Bad,
        Hate
    }
}
