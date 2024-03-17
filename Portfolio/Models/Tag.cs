namespace PortfolioAPI.Models
{
    public class Tag
    {
        public Tag() { }
        public Tag(Guid tagId, string name, string description) 
        {
            TagID = tagId;
            Name = name;
            Description = description;
        }

        public Guid TagID { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Post> Posts { get; } = new List<Post>();
    }

    public class PostTag
    {
        public Guid PostID { get; set; }
        public Guid TagID { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
