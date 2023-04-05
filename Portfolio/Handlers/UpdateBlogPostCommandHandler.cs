using AutoMapper;
using MediatR;
using Portfolio.CommandsQueries;
using Portfolio.Dtos;
using Portfolio.Exceptions;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Handlers
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
