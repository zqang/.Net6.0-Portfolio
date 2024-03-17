namespace PortfolioAPI.Handlers.Post.GetAllPost
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideoURL { get; set; } // Optional, depending on post types
        public Guid AuthorID { get; set; } // Assuming AuthorID is provided by the client
        public List<Guid> TagIds { get; set; } // Collection of tag IDs to be associated
        public bool Featured { get; set; }
        public string Status { get; set; }
        public string FeaturedImageURL { get; set; }
        public int ViewsCount { get; set; }
        public double AverageRating { get; set; }
        public List<Guid> CommentIds { get; set; }
    }
}
