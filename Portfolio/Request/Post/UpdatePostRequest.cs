namespace PortfolioAPI.Request.Post
{
    public class UpdatePostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideosURL { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Status { get; set; }
        public bool Featured { get; set; }
        public string FeaturedImageURL { get; set; }
        public List<Guid> TagIds { get; set; }
    }
}
