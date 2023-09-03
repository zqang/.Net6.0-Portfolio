using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;

namespace PortfolioAPI.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        //public DbSet<Project> Projects { get; set; }
        //// Add other model DbSet properties here

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Add model configuration here
        //    modelBuilder.Entity<BlogPost>()
        //        .HasOne(p => p.Project)
        //        .WithMany(b => b.BlogPosts)
        //        .HasForeignKey(p => p.ProjectId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
