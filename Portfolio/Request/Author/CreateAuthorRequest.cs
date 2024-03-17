namespace PortfolioAPI.Request.Author
{
    public class CreateAuthorRequest
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
    }
}
