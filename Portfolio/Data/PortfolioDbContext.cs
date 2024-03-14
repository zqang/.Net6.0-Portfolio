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
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<Project> Projects { get; set; }
        //// Add other model DbSet properties here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Posts)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorID)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .UsingEntity(j => j.ToTable("PostTag"));

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostID)
                .IsRequired();

            // Configure Comment entity
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany()
                .HasForeignKey(c => c.ParentCommentID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Reaction entity
            modelBuilder.Entity<Reaction>()
                .HasKey(ld => new { ld.ReactionID, ld.PostID, ld.UserID });

            modelBuilder.Entity<Reaction>()
                .HasOne(ld => ld.User)
                .WithMany(u => u.Reactions)
                .HasForeignKey(ld => ld.UserID);

            modelBuilder.Entity<Reaction>()
                .HasOne(ld => ld.Post)
                .WithMany(p => p.Reactions)
                .HasForeignKey(ld => ld.PostID);

            // Configure User entity
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            //modelBuilder.Entity<Post>()
            //    .HasKey(p => p.PostID);

            //modelBuilder.Entity<Post>(p =>
            //{
            //    p.Property(pi => pi.Title)
            //    .IsRequired()
            //    .HasColumnType("varchar(255)")
            //    .HasDefaultValue("No Title")
            //    .HasMaxLength(255);
            //    p.Property(pi => pi.Content)
            //    .IsRequired()
            //    .HasColumnType("varchar(max)")
            //    .HasDefaultValue("No Content");
            //    p.Property(pi => pi.VideoURL)
            //    .HasColumnType("varchar(200)")
            //    .HasMaxLength(200);
               
            //});
                
        }
    }
}
