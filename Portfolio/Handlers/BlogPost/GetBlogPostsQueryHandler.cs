﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Data;
using PortfolioAPI.Dtos;

namespace PortfolioAPI.Handlers
{
    public class GetBlogPostsQueryHandler : IRequestHandler<GetBlogPostsQuery, List<BlogPostDto>>
    {
        private readonly IMapper _mapper;
        private readonly PortfolioDbContext _context;

        public GetBlogPostsQueryHandler(IMapper mapper, PortfolioDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<BlogPostDto>> Handle(GetBlogPostsQuery request, CancellationToken cancellationToken)
        {
            var blogPosts = await _context.BlogPosts.ToListAsync(cancellationToken);
            return _mapper.Map<List<BlogPostDto>>(blogPosts);
        }
    }
}
