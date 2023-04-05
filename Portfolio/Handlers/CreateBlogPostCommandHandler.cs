using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.CommandsQueries;
using Portfolio.Data;
using Portfolio.Dtos;
using Portfolio.Models;
using Serilog;

namespace Portfolio.Handlers
{
    public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, BlogPostDto>
    {
        private readonly IMapper _mapper;
        private readonly PortfolioDbContext _context;

        public CreateBlogPostCommandHandler(IMapper mapper, PortfolioDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<BlogPostDto> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPost = _mapper.Map<BlogPost>(request);

            _context.BlogPosts.Add(blogPost);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // Log the inner exception
                Log.Error(ex.InnerException, "An error occurred while saving the blog post.");
            }
            

            return _mapper.Map<BlogPostDto>(blogPost);
        }
    }
}
