using PortfolioAPI.BuildingBlocks;

namespace PortfolioAPI.Models
{
    public class Post
    {
        public Post(Guid postID, string title, string content, string? videoURL, Guid authorID, string status,
            bool featured, string featuredImageURL)
        {
            PostID = postID;
            Title = title;
            Content = content;
            VideoURL = videoURL;
            AuthorID = authorID;
            Status = status;
            Featured = featured;
            FeaturedImageURL = featuredImageURL;
            PublicationDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            ViewsCount = 0;
            AverageRating = 0;
            _tags = new List<Tag>(); // Initialize the private collection
        }

        public Guid PostID { get; set; } // Primary Key
        public string Title { get; set; }
        public string Content { get; set; } // For text-based posts
        public string VideoURL { get; set; } // For video posts
        public Guid AuthorID { get; set; } // Foreign Key referencing Authors table
        public DateTime PublicationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int ViewsCount { get; set; }
        public string Status { get; set; }
        public bool Featured { get; set; }
        public string FeaturedImageURL { get; set; }
        public double AverageRating { get; set; }

        public Author Author { get; set; }

        private IList<Tag> _tags;
        private IList<Comment> _comments;
        private IList<Reaction> _reactions;
        public IReadOnlyList<Tag> Tags => _tags.ToList();
        public IReadOnlyList<Comment> Comments => _comments.ToList();
        public IReadOnlyList<Reaction> Reactions => _reactions.ToList();

        public void AddTags(IEnumerable<Tag> tags)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags), "Cannot add null tags");
            }

            foreach (var tag in tags)
            {
                if (tags == null)
                {
                    throw new ArgumentNullException(nameof(tags), "Cannot add null tags");
                }

                if (!_tags.Contains(tag)) // Avoid duplicates
                {
                    _tags.Add(tag);
                }
            }
        }

        public void AddTag(Tag tag)
        {
            if (!_tags.Contains(tag))
                _tags.Add(tag);
        }

        public void UpdateTags(IEnumerable<Tag> tags)
        {
            _tags.ReplaceAll(tags);
        }

        public void AddComments(IEnumerable<Comment> comments)
        {
            if (comments == null)
            {
                throw new ArgumentNullException(nameof(comments), "Cannot add null comments");
            }

            foreach (var tag in comments)
            {
                _comments.Add(tag);
            }
        }

        public void AddReactions(IEnumerable<Tag> tags)
        {
            //if (tags == null)
            //{
            //    throw new ArgumentNullException(nameof(tags), "Cannot add null tags");
            //}

            //foreach (var tag in tags)
            //{
            //    if (!_tags.Contains(tag)) // Avoid duplicates
            //    {
            //        _tags.Add(tag);
            //    }
            //}
        }
    }
}
