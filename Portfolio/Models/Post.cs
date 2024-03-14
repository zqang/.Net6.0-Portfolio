namespace PortfolioAPI.Models
{
    public class Post
    {
        public int PostID { get; set; } // Primary Key
        public string Title { get; set; }
        public string Content { get; set; } // For text-based posts
        public string VideoURL { get; set; } // For video posts
        public int AuthorID { get; set; } // Foreign Key referencing Authors table
        public DateTime PublicationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int ViewsCount { get; set; }
        public string Status { get; set; }
        public bool Featured { get; set; }
        public string FeaturedImageURL { get; set; }
        public double AverageRating { get; set; }

        public Author Author { get; set; }

        public ICollection<Tag> Tags { get; } = new List<Tag>();
        public ICollection<Comment> Comments { get; } = new List<Comment>();
        public ICollection<Reaction> Reactions { get; } = new List<Reaction>();
    }
}
