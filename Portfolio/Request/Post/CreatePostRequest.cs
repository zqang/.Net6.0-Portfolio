namespace PortfolioAPI.Request.Post
{
    public class CreatePostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public List<Guid> TagIds { get; set; }
        public bool Featured { get; set; }
        public string Status { get; set; }
        public string VideoURL { get; set; }
        public string FeaturedImageURL { get; set; }
    }
}
