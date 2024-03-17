﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioAPI.Data;

#nullable disable

namespace PortfolioAPI.Migrations
{
    [DbContext(typeof(PortfolioDbContext))]
    [Migration("20240316064605_AuthorUserRelationship")]
    partial class AuthorUserRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortfolioAPI.Models.Author", b =>
                {
                    b.Property<Guid>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AuthorID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("PortfolioAPI.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("PortfolioAPI.Models.Comment", b =>
                {
                    b.Property<Guid>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentCommentID")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentID");

                    b.HasIndex("ParentCommentID");

                    b.HasIndex("PostID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PortfolioAPI.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GithubUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("PortfolioAPI.Models.Post", b =>
                {
                    b.Property<Guid>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("FeaturedImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewsCount")
                        .HasColumnType("int");

                    b.HasKey("PostID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("PortfolioAPI.Models.Reaction", b =>
                {
                    b.Property<Guid>("ReactionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReactionAmounts")
                        .HasColumnType("int");

                    b.Property<int>("ReactionType")
                        .HasColumnType("int");

                    b.HasKey("ReactionID", "PostID", "UserID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("PortfolioAPI.Models.Tag", b =>
                {
                    b.Property<Guid>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TagDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PortfolioAPI.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<Guid>("PostsPostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagsTagID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostsPostID", "TagsTagID");

                    b.HasIndex("TagsTagID");

                    b.ToTable("PostTag", (string)null);
                });

            modelBuilder.Entity("PortfolioAPI.Models.Author", b =>
                {
                    b.HasOne("PortfolioAPI.Models.User", "User")
                        .WithOne("Author")
                        .HasForeignKey("PortfolioAPI.Models.Author", "UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PortfolioAPI.Models.Comment", b =>
                {
                    b.HasOne("PortfolioAPI.Models.Comment", "ParentComment")
                        .WithMany()
                        .HasForeignKey("ParentCommentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PortfolioAPI.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentComment");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("PortfolioAPI.Models.Post", b =>
                {
                    b.HasOne("PortfolioAPI.Models.Author", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PortfolioAPI.Models.Reaction", b =>
                {
                    b.HasOne("PortfolioAPI.Models.Post", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioAPI.Models.User", "User")
                        .WithMany("Reactions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("PortfolioAPI.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioAPI.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfolioAPI.Models.Author", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("PortfolioAPI.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("PortfolioAPI.Models.User", b =>
                {
                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}
