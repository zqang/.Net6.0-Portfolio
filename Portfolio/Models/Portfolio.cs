using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PortfolioAPI.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GithubUrl { get; set; }
        public string? Description { get; set; }
    }
}
