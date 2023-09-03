using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Exceptions;
using PortfolioAPI.Repositories;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Data;
using PortfolioAPI.Dtos;
using PortfolioAPI.Models;

namespace PortfolioAPI.Handlers
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
