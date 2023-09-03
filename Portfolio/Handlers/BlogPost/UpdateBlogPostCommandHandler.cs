using AutoMapper;
using MediatR;
using PortfolioAPI.Exceptions;
using PortfolioAPI.Models;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Dtos;
using PortfolioAPI.Repositories;

namespace PortfolioAPI.Handlers
{
    public class UpdateBlogPostCommandHandler : IRequestHandler<UpdateBlogPostCommand, BlogPostDto>
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;

        public UpdateBlogPostCommandHandler(IMapper mapper, IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPostDto> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(request.Id);

            if (blogPost == null)
            {
                throw new NotFoundException(nameof(BlogPost), request.Id);
            }

            _mapper.Map(request, blogPost);

            await _blogPostRepository.UpdateAsync(blogPost);

            return _mapper.Map<BlogPostDto>(blogPost);
        }
    }
}
