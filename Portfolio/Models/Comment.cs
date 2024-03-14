namespace PortfolioAPI.Models
{
    public class Comment
    {
        public int CommentID { get; set; } // Primary Key
        public int PostID { get; set; } // Foreign Key referencing Posts table
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string Status { get; set; }
        public int? ParentCommentID { get; set; } // Nullable for nested comments
        
        public Post Post { get; set; }
        public Comment ParentComment { get; set; }
    }

}
