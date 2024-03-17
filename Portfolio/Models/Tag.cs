namespace PortfolioAPI.Models
{
    public class Tag
    {
        public Guid TagID { get; set; } // Primary Key
        public string TagName { get; set; }
        public string TagDescription { get; set; }

        public ICollection<Post> Posts { get; } = new List<Post>();
    }

    public class PostTag
    {
        public Guid PostID { get; set; }
        public Guid TagID { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
