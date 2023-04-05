using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.CommandsQueries;
using Portfolio.Data;
using Portfolio.Dtos;
using Portfolio.Exceptions;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Handlers
{
    public class GetBlogPostQueryHandler : IRequestHandler<GetBlogPostQuery, BlogPostDto>
    {
        private readonly IMapper _mapper;
        private readonly PortfolioDbContext _context;

        public GetBlogPostQueryHandler(IMapper mapper, PortfolioDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<BlogPostDto> Handle(GetBlogPostQuery request, CancellationToken cancellationToken)
        {
            var blogPost = await _context.BlogPosts.FindAsync(request.Id);

            if (blogPost == null)
            {
                throw new NotFoundException(nameof(BlogPost), request.Id);
            }

            return _mapper.Map<BlogPostDto>(blogPost);
        }
    }
}
