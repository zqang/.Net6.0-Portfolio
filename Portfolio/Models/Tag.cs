namespace PortfolioAPI.Models
{
    public class Tag
    {
        public int TagID { get; set; } // Primary Key
        public string TagName { get; set; }
        public string TagDescription { get; set; }

        public ICollection<Post> Posts { get; } = new List<Post>();
    }
}
